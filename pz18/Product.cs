using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz18
{
    enum Category
    {
        Clothes,
        Shoes,
        Accessories
    }

    class Product
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }

        private static int totalCount = 0;
        private static decimal totalCost = 0;

        public Product(string name, Category category, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Строка не может быть пустой", nameof(name));
            }

            if (price <= 0)
            {
                throw new ArgumentException("Цена не может быть ниже 0", nameof(price));
            }

            Name = name;
            Category = category;
            Price = price;

            totalCount++;
            totalCost += price;
        }

        public static void DisplayTotalInfo()
        {
            Console.WriteLine($"Общая стоимость продуктов: {totalCount}");
            Console.WriteLine($"Полная стоимость продуктов: {totalCost}");
            Console.WriteLine($"Средняя стоимость продуктов: {totalCost / totalCount}");
        }

        public void SellProduct()
        {
            decimal discount;
            switch (Category)
            {
                case Category.Clothes:
                    discount = 0.05m;
                    break;
                case Category.Shoes:
                    discount = 0.07m;
                    break;
                case Category.Accessories:
                    discount = 0.1m;
                    break;
                default:
                    discount = 0;
                    break;
            }

            decimal discountedPrice = Price - (Price * discount);

            Console.WriteLine($"Продаваемый продукт {Name}");
            Console.WriteLine($"Категория: {Category}");
            Console.WriteLine($"Цена до скидки: {Price}");
            Console.WriteLine($"Цена после скидки: {discountedPrice}");

            totalCount--;
            totalCost -= Price;
        }
    }
}
