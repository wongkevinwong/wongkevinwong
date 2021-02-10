using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WebTechTest.Wcf.Service;

namespace WebTechTest.Wcf.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            HostService();
        }

        private static void HostService()
        {
            var serviceHost = new ServiceHost(typeof(ProductsService));

            try
            {
                serviceHost.AddServiceEndpoint(typeof(IProductsService), new WSHttpBinding(), "ProductsService");                

                serviceHost.Open();

                Console.WriteLine("Products service has been started");

                Console.WriteLine("Press enter to terminate the service");

                Console.ReadLine();

                serviceHost.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred");

                Console.WriteLine(ex.Message);

                Console.WriteLine("Press enter to close the app");
                Console.ReadLine();

            }
        }
    }
}
