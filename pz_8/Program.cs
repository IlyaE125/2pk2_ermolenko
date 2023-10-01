namespace pz_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray = new int[15][];  // Создаем ступенчатый массив с длиной 15
            Random random = new Random();
            // Генерируем второе измерение каждого элемента массива
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                int length = random.Next(2, 16);  // Длина второго измерения от 2 до 15
                jaggedArray[i] = new int[length];
            }
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] = random.Next(1, 101);  
                }
            }
            Console.WriteLine("Исходный ступенчатый массив:");
            PrintJaggedArray(jaggedArray);  // Выводим исходный массив

            int[] lastElements = new int[jaggedArray.Length];
            int[] maxElements = new int[jaggedArray.Length];

            // Записываем последние элементы каждой строки в одномерный массив
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                lastElements[i] = jaggedArray[i][jaggedArray[i].Length - 1];
            }
            Console.WriteLine("Массив последних элементов:");
            PrintArray(lastElements);  // Выводим массив последних элементов

            // Находим максимальные элементы в каждой строке
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                int maxElement = int.MinValue;
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    if (jaggedArray[i][j] > maxElement)
                    {
                        maxElement = jaggedArray[i][j];
                    }
                }
                maxElements[i] = maxElement;
            }
            Console.WriteLine("Массив максимальных элементов в каждой строке:");
            PrintArray(maxElements);  // Выводим массив максимальных элементов
            // Меняем местами первый элемент и максимальный элемент в каждой строке
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                int maxElementIndex = Array.IndexOf(jaggedArray[i], maxElements[i]);
                int temp = jaggedArray[i][0];
                jaggedArray[i][0] = maxElements[i];
                jaggedArray[i][maxElementIndex] = temp;
            }
            Console.WriteLine("Обновленный массив после замены:");
            PrintJaggedArray(jaggedArray);  // Выводим обновленный массив
            // Реверс каждой строки ступенчатого массива
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Array.Reverse(jaggedArray[i]);
            }
            Console.WriteLine("Массив после реверса каждой строки:");
            PrintJaggedArray(jaggedArray);  // Выводим массив после реверса
        }
        // Метод для вывода ступенчатого массива
        static void PrintJaggedArray(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        // Метод для вывода одномерного массива
        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}