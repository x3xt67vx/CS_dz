using System;
using System.Collections.Generic;
using System.IO;
namespace ConsoleApp3_CS
{
    public class tasks2
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
            Console.WriteLine("\nЭадача 5:");
            Task5();
        }

        
        
        public class BankAccount
        {
            private decimal balance;

            public BankAccount()
            {
                balance = 0;
            }

            public void Deposit(decimal amount)
            {
                balance += amount;
            }

            public void Withdraw(decimal amount)
            {
                if (amount > balance)
                {
                    throw new InvalidOperationException("Недостаточно средств");
                }
                balance -= amount;
            }

            public decimal GetBalance()
            {
                return balance;
            }
        }
        public class Translator
        {
            private Dictionary<string, string> dictionary;

            public Translator()
            {
                dictionary = new Dictionary<string, string>
                {
                    { "apple", "яблоко" },
                    { "dog", "собака" }
                };
            }

            public string Translate(string word)
            {
                if (dictionary.TryGetValue(word, out string translation))
                {
                    return translation;
                }
                throw new KeyNotFoundException("Ошибка: Слово не найдено");
            }
        }       
        
        public class Warehouse
        {
            private Dictionary<string, int> products;

            public Warehouse()
            {
                products = new Dictionary<string, int>();
            }

            public void AddProduct(string name, int quantity)
            {
                if (products.ContainsKey(name))
                {
                    products[name] += quantity;
                }
                else
                {
                    products[name] = quantity;
                }
            }

            public void RemoveProduct(string name, int quantity)
            {
                if (products.ContainsKey(name))
                {
                    if (products[name] >= quantity)
                    {
                        products[name] -= quantity;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Ошибка: Недостаточно товара {name}");
                    }
                }
                else
                {
                    throw new KeyNotFoundException($"Ошибка: Товар {name} не найден");
                }
            }

            public int GetProductQuantity(string name)
            {
                if (products.ContainsKey(name))
                {
                    return products[name];
                }
                return 0;
            }
        }
        private static void  Task1()
        {
            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Привет, {name}!");
        }
        private static void Task2()
        {
            BankAccount account = new BankAccount();
            account.Deposit(2000);
            account.Withdraw(500);

            try
            {
                account.Withdraw(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine($"Баланс после операций: {account.GetBalance()}");
        }

        private static void Task3()
        {
            Console.Write("Введите ваш возраст: ");
            string input = Console.ReadLine();

            try
            {
                int age = int.Parse(input);
                if (age < 0)
                {
                    throw new ArgumentException("Ошибка: возраст не может быть отрицательным!");
                }
                Console.WriteLine($"Ваш возраст: {age}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введите корректное число!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        private static void Task4()
        {
            Translator translator = new Translator();

            try
            {
                Console.WriteLine(translator.Translate("apple"));
                Console.WriteLine(translator.Translate("dog"));
                Console.WriteLine(translator.Translate("car"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Task5()
        {
            Warehouse warehouse = new Warehouse();
            warehouse.AddProduct("Яблоки", 50);
            warehouse.AddProduct("Молоко", 30);

            warehouse.RemoveProduct("Яблоки", 20);

            try
            {
                warehouse.RemoveProduct("Молоко", 40);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Остаток Яблоки: {warehouse.GetProductQuantity("Яблоки")}");
        }
        
    }
}

