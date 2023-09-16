using System.ComponentModel.Design;

namespace pz_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
           
            int i = int.Parse(Console.ReadLine());

                Console.WriteLine($"мне{i}");
                if (i >= 11 && i <= 14) 
                {
                    Console.WriteLine("лет");
                    Int32 lastnumber = i % 10;
                }
                else
                {
                    Int32 lastnumber = i % 10;
                    switch (lastnumber)
                    {
                        
                        case 1:
                            Console.WriteLine("год");
                            break;
                        case 2:
                        case 3:
                        case 4:
                            Console.WriteLine("года");
                            break;
                        default:
                            Console.WriteLine("лет");
                            break;
                    }
                }
            }

        }
    }
