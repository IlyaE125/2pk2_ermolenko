namespace pz_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ввод катетов первого треугольника
            Console.Write("Введите катет a1: ");
            double a1 = double.Parse(Console.ReadLine());
            Console.Write("Введите катет b1: ");
            double b1 = double.Parse(Console.ReadLine());

            // Ввод катетов второго треугольника
            Console.Write("Введите катет a2: ");
            double a2 = double.Parse(Console.ReadLine());
            Console.Write("Введите катет b2: ");
            double b2 = double.Parse(Console.ReadLine());

            // Вычисление площадей и периметров треугольников
            double area1, area2, perimeter1, perimeter2;
            AreaAndPerimeter(a1, b1, out area1, out perimeter1);
            AreaAndPerimeter(a2, b2, out area2, out perimeter2);

            // Вывод результатов
            Console.WriteLine("Площадь первого треугольника: " + area1);
            Console.WriteLine("Периметр первого треугольника: " + perimeter1);
            Console.WriteLine("Площадь второго треугольника: " + area2);
            Console.WriteLine("Периметр второго треугольника: " + perimeter2);

            // Сравнение площадей и периметров треугольников
            if (area1 > area2)
            {
                Console.WriteLine("Площадь первого треугольника больше площади второго треугольника");
            }
            else if (area1 < area2)
            {
                Console.WriteLine("Площадь второго треугольника больше площади первого треугольника");
            }
            else
            {
                Console.WriteLine("Площади треугольников равны");
            }

            if (perimeter1 > perimeter2)
            {
                Console.WriteLine("Периметр первого треугольника больше периметра второго треугольника");
            }
            else if (perimeter1 < perimeter2)
            {
                Console.WriteLine("Периметр второго треугольника больше периметра первого треугольника");
            }
            else
            {
                Console.WriteLine("Периметры треугольников равны");
            }

            Console.ReadKey();
        }

        static void AreaAndPerimeter(double a, double b, out double area, out double perimeter)
        {
            // Вычисление площади
            area = a * b / 2;

            // Вычисление гипотенузы
            double c = Math.Sqrt(a * a + b * b);

            // Вычисление периметра
            perimeter = a + b + c;
        }
    }
}
