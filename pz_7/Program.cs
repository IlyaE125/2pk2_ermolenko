namespace pz_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i, j;
            int[,] arr = new int[5, 5];
            Console.WriteLine(" массив arr: ");
            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 5; j++)
                {
                    arr[i, j] = Math.Abs(i - j) + 1;
                    Console.Write(arr[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}