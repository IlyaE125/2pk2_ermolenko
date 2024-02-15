namespace pz18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("T-shirt", Category.Clothes, 500);
            Product product2 = new Product("Shoes", Category.Shoes, 1000);

            
            product1.SellProduct();
            product2.SellProduct();

            
            Product.DisplayTotalInfo();

            Console.ReadLine();
        }
    }
}
