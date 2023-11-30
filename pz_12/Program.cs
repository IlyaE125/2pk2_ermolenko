namespace pz_12
{
    internal class Program
    {
          static bool CheckFormula(string formula)
          {
                int count = 0;

                foreach (char sym in formula)
                {
                    if (sym == '(')
                        count++;
                    else if (sym == ')')
                        count--;

                    // Если количество закрывающих скобок больше открывающих,
                    // то формула некорректна
                    if (count < 0)
                        return false;
                }

                // Если количество открывающих и закрывающих скобок одинаково,
                // то формула корректна
                return count == 0;
          }
            static void Main(string[] args)
            {
                string formula = Console.ReadLine();
                bool result = CheckFormula(formula);

                Console.WriteLine(result);
            }
        
    }
}
