namespace pz_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           double a = double.Parse(Console.ReadLine());    //объявляем переменные а и б
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double result;
            result = Math.Abs((Math.Pow(a, 2) - Math.Pow(b, 2)) / (Math.Sin(b))); //возведение в степень и деление на синус б

            double x;
            x = Math.Pow(10, 4);//число 10 в 4 ст

            double k;
            k = Math.Abs(Math.Sin(a + b) - (b * c)); // вычисление выражения под корнем
            
            k = Math.Pow(k, 1.0 / 5); //корень в 5 степени
            double d;
            d = (4 - Math.Tan(a)) / (Math.Pow(Math.PI, 3)); // последнее выражение
            double f = result - (x * k) - d;
            Console.WriteLine(f);


        }
    }
}