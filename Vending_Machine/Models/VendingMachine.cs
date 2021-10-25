using System;
using System.Collections.Generic;
using System.Text;
using Vending_Machine.Data;
namespace Vending_Machine.Models
{
    public class VendingMachine : IVending
    {

        protected static bool stopService = false;
        public static void StartService()
        {
            //Write code to Load products in ProductCollection
            while (!stopService)
                Welcome();
        }
        public  string EndTransaction()
        {
            Payment ob = new Payment();

            string message = ob.PayBalance(out uint[] balanceInDenominatio);
            stopService = true;
            return message;
        }

        public static void Welcome()
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



        public Product[] SearchProducts(string searchProduct)
        {
            return ProductItems.FindByName(searchProduct);

        }

        public  Product[] ShowAll()
        {
            return ProductItems.FindAll();
        }

        public string InsertMoney(uint amount)
        {
            Payment ob = new Payment();
            return ob.AddToMoneyPool(amount);

        }
        public string Purchase(Product purchaseProduct, out bool charged)
        {

            string message = $"\nSorry! Not enough money to buy. Insert money";
            Payment ob = new Payment();
            charged = ob.ChargePrice(purchaseProduct.ProductPrice);

            if (charged)
            {


                if (purchaseProduct is Product_Drink)
                    message = $"\nPayment successfull" + (purchaseProduct as Product_Drink).UseProduct();
                else if (purchaseProduct is Product_Snack)
                    message = $"\nPayment successfull" + (purchaseProduct as Product_Snack).UseProduct();
                else if (purchaseProduct is Product_Ticket)
                    message = $"\nPayment successfull" + (purchaseProduct as Product_Ticket).UseProduct();
                else if (purchaseProduct is Product_Card)
                    message = $"\nPayment successfull" + (purchaseProduct as Product_Card).UseProduct();
                else if (purchaseProduct is Product_Game)
                    message = $"\nPayment successfull" + (purchaseProduct as Product_Game).UseProduct();

            }


            return message;
        }


        public static void ContinueBuying()
        {
            Welcome();
        }

    }
}
