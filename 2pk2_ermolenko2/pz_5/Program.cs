namespace pz_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = (n % 2 == 0) ? n + 1 : n;
            int s = m * 2;
            int sum = 0;
            int z = m;
            while (z <= s)
            {
                if (z % 2 != 0)
                {
                    sum += z;
                }
                z++;
            }
            Console.WriteLine("Сумма всех нечетных чисел от " + m + " до " + s + ": " + sum);

        }
    }
}