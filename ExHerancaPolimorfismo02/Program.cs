using System.Globalization;
using ExHerancaPolimorfismo02.Entities;

namespace ExHerancaPolimorfismo02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number od products: ");
            int n = int.Parse(Console.ReadLine());
            List<Product> products = new List<Product>();

            Console.WriteLine();

            for (int i=1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char type = char.Parse(Console.ReadLine());
                while (type != 'u' && type != 'i' && type != 'c') {
                    Console.Write("Common, used or imported (c/u/i)? ");
                    type = char.Parse(Console.ReadLine());
                }
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: $ ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (type == 'i')
                {
                    Console.Write("Customs fee: $ ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    products.Add(new ImportedProduct(name, price, customsFee));
                }
                else if (type == 'u')
                {
                    Console.Write("Manufacture date: (DD/MM/YYYY): ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                    products.Add(new UsedProduct(name, price, manufactureDate));    
                }
                else {
                    products.Add(new Product(name, price));
                }
                

                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");
            foreach (Product product in products) {
                Console.WriteLine(product.PriceTag());
            }
            
        }
    }
}