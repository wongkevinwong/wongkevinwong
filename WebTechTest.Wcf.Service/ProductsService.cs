using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebTechTest.Wcf.Service.Models;

namespace WebTechTest.Wcf.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductsService : IProductsService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product(){Id = 1, Name = "Product A", Price = 1},
                new Product(){Id = 1, Name = "Product B", Price = 2},
                new Product(){Id = 1, Name = "Product C", Price = 3},
                new Product(){Id = 1, Name = "Product D", Price = 4},
                new Product(){Id = 1, Name = "Product E", Price = 5},
                new Product(){Id = 1, Name = "Product F", Price = 6},
                new Product(){Id = 1, Name = "Product G", Price = 7}
            };
        }
    }
}
