using System;
using System.Globalization;

namespace pz_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] Array = new int[50];
            for (int i = 0; i < 50 ; i++)
            {
                Array[i] = i;
            }
            Console.WriteLine(Array);
            int num = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] >= 15)
                {
                    Array[num] = Array[i];
                    num++;
                }    
            }
            for (int i = num; i < Array.Length; i++)
            {
                Array[i] = 0;
            }

            Console.WriteLine("Массив после исключения элементов меньше 15:");
            PrintArray(Array);
        }
        static void PrintArray(int[] arr)
        {
            foreach (var number in arr)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}