namespace pz_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double x;
            double y;
            if (c > 7.1)
            {
                x = Math.Cos(c + (Math.Sqrt(a + Math.Pow(c, 2))) / 1.5);

            }
            else
            {
                x = Math.Sin(2 * c + a) + 14 + a;
            }
            if (x<= 0)
            {
                x = Math.Abs(c) * a + 2.4 * Math.Cos(3 + a * x) + x;
            }
            else
            {
                y = a * Math.Pow(x, 2) - 2 * c * x;
            }
            double t;
            t = (c + 11.2 * Math.Pow(a, 3)) / (2.7 * Math.Pow(x, 2) + 1.7 * Math.Pow(a, 2) + 3);
            Console.WriteLine(t);
        }

    }
}