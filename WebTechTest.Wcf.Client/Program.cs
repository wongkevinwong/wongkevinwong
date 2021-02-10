using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTechTest.Wcf.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductsService.ProductsServiceClient client = new ProductsService.ProductsServiceClient();
            var products = client.GetProducts();

            foreach(var product in products)
            {
                Console.WriteLine($"{product.Id} {product.Name} {product.Price}");
            }

            Console.WriteLine("Completed");
            Console.ReadLine();
        }
    }
}
