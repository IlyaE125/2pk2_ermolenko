namespace pz_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 20;
            int b = 80;
            int c = 4;
            for (int i = a; i <= b; i += c)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
            /*задание 2*/
            char K = 'k';
            int d = 6;
            K = char.ToUpper(K);
            for (int y = 0; y < d; y++)
            {
                char x = (char)(K + y);
                Console.WriteLine(x);
            }
            Console.ReadLine();
            /*задание 3*/
            int p = 3;
            int t = 4;
            string е = "#";
            for (int i = 0; i < t; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    string s = е;
                    Console.Write(е);
                }
                Console.WriteLine();
                Console.ReadLine();


            }
            /*задание 4*/
            int z1 = -300;
            int z2 = 200;
            int z3 = 10;
            int z4 = 0;
            for (int z5 = z1; z5 < z2; z5++)
            {
                if (z5 % z3 == 0)
                {
                    Console.Write(z5 + " ");
                    z4++;

                }

            }
            /*задание 5*/
            for (int r1 =4, r2 = 40; Math.Abs(r1 - r2)!= 19; r1++, r2--)
            {
                Console.WriteLine($"r1 = {r1}, r2 = {r2}");
            }    
            

        }
    }
}

