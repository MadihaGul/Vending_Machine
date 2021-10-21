using System;
using System.Collections.Generic;
using System.Text;
using Vending_Machine.Data;
namespace Vending_Machine.Models
{
    interface IVending
    {
        protected static bool stopService = false;
        public void StartService()
        {
            //Write code to Load products in ProductCollection
            while (!stopService)
             Welcome();
        }
        public string EndTransaction()
        {
            stopService = true;
            return "";
        }

        public void Welcome()
        {
            try
            {
                Console.WriteLine("Welcome! What would you like to buy\n1.\t Show All\n2.\tSearch");
                int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Error! Invalid choice");

            }
        }



        Product[] SearchProducts(string searchProduct)
        {
            return ProductItems.FindByName(searchProduct);

        }
  

        Product[] ShowAll()
        {
            return ProductItems.FindAll();
        }

        void InsertMoney(double addMoney)
        {

        }
        void Purchase(Product PurchaseProduct)
        {

        }


        void ContinueBuying()
        {

        }

    }
}
