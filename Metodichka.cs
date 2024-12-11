using System;
using System.Collections.Generic;
using System.IO;

namespace DZ7
{
    internal class Metodichka
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5("ФИО и Email.txt", "Email.txt");
            Task6();
            Console.ReadKey();
        }

        static void Task1()
        {
            Console.WriteLine("Упражнение 8.1");
            Console.WriteLine("Банковский счет");

            BankAccount account = new BankAccount(1000, BankAccountType.Checking);
            BankAccount account1 = new BankAccount(1000, BankAccountType.Checking);

            Console.WriteLine($"Номер счета: {account.AccountNumber}");
            Console.WriteLine($"Баланс: ${account.Balance}");
            Console.WriteLine("--------------------");
            Console.WriteLine($"Номер счета: {account1.AccountNumber}");
            Console.WriteLine($"Баланс: ${account1.Balance}");

            decimal transferAmount;
            bool isValidAmount = false;

            while (!isValidAmount)
            {
                Console.WriteLine($"Сколько $ вы хотите перевести со счета №{account.AccountNumber} на счет №{account1.AccountNumber}?");
                isValidAmount = decimal.TryParse(Console.ReadLine(), out transferAmount);
                if (!isValidAmount || transferAmount < 0)
                {
                    Console.WriteLine("Это не положительное число!");
                    isValidAmount = false;
                }
                else
                {
                    account.Transfer(account1, transferAmount);
                    Console.WriteLine($"Новый баланс счета №{account.AccountNumber}: ${account.Balance}");
                    Console.WriteLine($"Новый баланс счета №{account1.AccountNumber}: ${account1.Balance}");
                }
            }
        }

        static void Task2()
        {
            Console.WriteLine("Упражнение 8.2");
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Вы ввели пустую строку.");
                return;
            }

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            string reversed = new string(charArray);
            Console.WriteLine($"Строка в обратном порядке: {reversed}");
        }

        static void Task3()
        {
            Console.WriteLine("Упражнение 8.3");
            Console.WriteLine("Введите имя файла для чтения:");
            string inputFilePath = Console.ReadLine();

            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Файл не существует. Программа завершает работу.");
                return;
            }

            string outputFilePath = "output.txt";

            try
            {
                string content = File.ReadAllText(inputFilePath);
                string upperContent = content.ToUpper();
                File.WriteAllText(outputFilePath, upperContent);
                Console.WriteLine($"Содержимое файла '{inputFilePath}' было успешно скопировано в '{outputFilePath}' в заглавных буквах.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при обработке файла: {ex.Message}");
            }
        }

        static void Task4()
        {
            Console.WriteLine("Упражнение 8.4");
            Console.WriteLine("Введите значение для проверки:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                Console.WriteLine($"Реализует ли интерфейс IFormattable: {number is IFormattable}");
            }
            else if (double.TryParse(input, out double doubleNumber))
            {
                Console.WriteLine($"Реализует ли интерфейс IFormattable: {doubleNumber is IFormattable}");
            }
            else
            {
                Console.WriteLine($"Реализует ли интерфейс IFormattable: {input is IFormattable}");
            }
        }

        static void Task5(string inputFile, string outputFile)
        {
            Console.WriteLine("Домашнее задание 8.1");

            try
            {
                using (StreamReader reader = new StreamReader(inputFile))
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('#');
                        if (parts.Length == 2)
                        {
                            string email = parts[1].Trim();
                            writer.WriteLine(email);
                        }
                    }
                }

                Console.WriteLine("Адреса электронной почты записаны в файл.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Файл не найден: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка обработки файла: {ex.Message}");
            }
        }

        static void Task6()
        {
            Console.WriteLine("Домашнее задание 8.2");
            List<Song> songs = new List<Song>();
            int songCount;

            Console.Write("Введите количество песен: ");
            while (!int.TryParse(Console.ReadLine(), out songCount) || songCount <= 0)
            {
                Console.Write("Пожалуйста, введите положительное число: ");
            }

            for (int i = 0; i < songCount; i++)
            {
                Console.Write($"Введите название песни {i + 1}: ");
                string name = Console.ReadLine();

                Console.Write($"Введите автора песни {i + 1}: ");
                string author = Console.ReadLine();

                Song prev = i > 0 ? songs[i - 1] : null;
                Song song = new Song(name, author, prev);
                songs.Add(song);
            }

            foreach (Song song in songs)
            {
                Console.WriteLine(song.Title());
            }

            if (songs.Count > 1 && songs[0].Equals(songs[1]))
            {
                Console.WriteLine("Первая и вторая песни в списке равны.");
            }
            else
            {
                Console.WriteLine("Первая и вторая песни в списке не равны.");
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения");
        }
    }
}
