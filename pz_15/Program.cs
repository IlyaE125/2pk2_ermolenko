using System;
using System.IO;
namespace pz_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь к каталогу: ");
            string directoryPath = Console.ReadLine();

            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Указанный каталог не существует.");
                return;
            }

            string[] files = Directory.GetFiles(directoryPath);

            if (files.Length == 0)
            {
                Console.WriteLine("В указанном каталоге нет файлов.");
                return;
            }

            Console.WriteLine("Список файлов:");
            foreach (string filePath in files)
            {
                Console.WriteLine(Path.GetFileName(filePath));
            }

            Console.WriteLine();

            while (true)
            {
                Console.Write("Введите имя файла (без расширения) или \"Выход\" для выхода: ");
                string fileName = Console.ReadLine();

                if (fileName.ToLower() == "выход")
                {
                    break;
                }

                string filePathToCompare = Path.Combine(directoryPath, fileName + ".txt");

                if (!File.Exists(filePathToCompare))
                {
                    Console.WriteLine("Указанный файл не существует.");
                    continue;
                }

                foreach (string filePath in files)
                {
                    if (string.Equals(filePath, filePathToCompare, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    if (FileCompare(filePath, filePathToCompare))
                    {
                        Console.WriteLine($"Файл \"{Path.GetFileName(filePath)}\" содержит идентичное содержимое.");
                    }
                }
            }
        }

        static bool FileCompare(string file1, string file2)
        {
            int file1Byte;
            int file2Byte;

            using (FileStream fs1 = new FileStream(file1, FileMode.Open))
            using (FileStream fs2 = new FileStream(file2, FileMode.Open))
            {
                if (fs1.Length != fs2.Length)
                {
                    return false;
                }

                do
                {
                    file1Byte = fs1.ReadByte();
                    file2Byte = fs2.ReadByte();
                }
                while ((file1Byte == file2Byte) && (file1Byte != -1));
            }

            return (file1Byte - file2Byte) == 0;
        }
    }
}
