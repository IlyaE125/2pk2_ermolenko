using System;
using System.IO;
using System.Text.RegularExpressions;
namespace pz_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст:");

            // Создаем объект для записи данных в файл
            StreamWriter writer = new StreamWriter("inFile.txt");

            string input;
            int num = 0;

            do
            {
                // Считываем ввод пользователя
                input = Console.ReadLine();

                // Записываем ввод в файл
                writer.WriteLine(input);

                // Проверяем текст на наличие чисел
                if (ContainsNumbers(input))
                {
                    num++;
                }
            } while (!string.IsNullOrEmpty(input));

            writer.Close();

            Console.WriteLine("Количество чисел в тексте: " + num);
            Console.WriteLine("Содержимое файла inFile.txt:");
            Console.WriteLine(File.ReadAllText("inFile.txt"));
            Console.ReadLine();
        }

        static bool ContainsNumbers(string input)
        {
            // Проверяем, содержит ли текст числа
            return Regex.IsMatch(input, @"\d");
        }
    }
}
