namespace pz_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());         
            int m = (n % 2 == 0) ? n + 1 : n;
            int upperLimit = m * 2;
            int sum = 0;
            int currentNumber = m;
            while (currentNumber <= upperLimit)
            {
                if (currentNumber % 2 != 0)
                {
                    sum += currentNumber;
                }
                currentNumber++;
            }
            Console.WriteLine("Сумма всех нечетных чисел от " + m + " до " + upperLimit + ": " + sum);
        }
    }
}