namespace pz_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string first = "просмотр сериала";
            string second = "заняться важным делом";
            string result = "";

            string[] firstWords = first.Split(' ');
            string[] secondWords = second.Split(' ');

            int minLength = Math.Min(firstWords.Length, secondWords.Length);

            for (int i = 0; i < minLength; i++)
            {
                result += firstWords[i] + " " + secondWords[i] + " ";
            }

            if (firstWords.Length > secondWords.Length)
            {
                result += string.Join(" ", firstWords, secondWords.Length, firstWords.Length - secondWords.Length);
            }
            else if (secondWords.Length > firstWords.Length)
            {
                result += string.Join(" ", secondWords, firstWords.Length, secondWords.Length - firstWords.Length);
            }

            Console.WriteLine(result);
        }
    }
}
