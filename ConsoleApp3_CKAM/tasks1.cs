using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp3_CKAM
{
    public class tasks1
    {
        public static void Build()
        {
            Console.WriteLine("Задача 1");
            Task1();

            Console.WriteLine("\nЗадача 2");
            Task2();

            Console.WriteLine("\nЗадача 3");
            Task3();

            Console.WriteLine("\nЗадача 4");
            Task4();
        }

        private static void Task1()
        {
            int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 0; i < array.Length; i += 2)
            {
                array[i] = array.Length - 1 - i;
            }

            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
        }

        private static void Task2()
        {
            int[] array = new int[10];

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Введите число {i + 1}: ");
                array[i] = int.Parse(Console.ReadLine());
            }

            HashSet<int> uniqueElements = new HashSet<int>(array);

            Console.WriteLine("Уникальные элементы:");
            foreach (int num in uniqueElements)
            {
                Console.Write(num + " ");
            }
        }

        private static void Task3()
        {
            List<int> array = new List<int>();
            string input;

            while (true)
            {
                Console.Write("Введите число (или оставьте пустым для завершения): ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;
                array.Add(int.Parse(input));
            }

            array.Sort();

            Console.Write("Введите число для поиска: ");
            int target = int.Parse(Console.ReadLine());

            int index = BinarySearch(array, target);

            if (index != -1)
            {
                Console.WriteLine($"Число найдено на индексе: {index}");
            }
            else
            {
                Console.WriteLine("Число не найдено в массиве.");
            }
        }

        static int BinarySearch(List<int> array, int target)
        {
            int left = 0, right = array.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] == target)
                    return mid;

                if (array[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        private static void Task4()
        {
            Console.Write("Введите количество вершин: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Введите количество ребер: ");
            int m = int.Parse(Console.ReadLine());

            List<(int, int, int)> edges = new List<(int, int, int)>();

            for (int i = 0; i < m; i++)
            {
                Console.WriteLine($"Введите ребро {i + 1} в формате u v w (начальная вершина, конечная вершина, вес):");
                Console.Write("Начальная вершина (u): ");
                int u = int.Parse(Console.ReadLine());
                Console.Write("Конечная вершина (v): ");
                int v = int.Parse(Console.ReadLine());
                Console.Write("Вес ребра (w): ");
                int w = int.Parse(Console.ReadLine());
                edges.Add((u, v, w));
            }

            string plantUmlCode = GeneratePlantUmlCode(n, edges);

            string relativePath = @"../../../graph.puml";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);
            string absolutePath = Path.GetFullPath(filePath);

            try
            {
                File.WriteAllText(absolutePath, plantUmlCode);
                Console.WriteLine($"PlantUML код успешно сохранен в файл '{absolutePath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении файла: {ex.Message}");
            }
        }

        static string GeneratePlantUmlCode(int n, List<(int, int, int)> edges)
        {
            var code = new List<string> { "@startuml", "graph \"Неориентированный граф\" {" };

            for (int i = 0; i < n; i++)
            {
                code.Add($"node \"{i}\" as {i}");
            }

            foreach (var edge in edges)
            {
                code.Add($"{edge.Item1} -- {edge.Item2} : {edge.Item3}");
            }

            code.Add("}");
            code.Add("@enduml");

            return string.Join("\n", code);
        }
    }
}
