using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine.Data
{
    public class ProductIdSequencer
    {
        // Created private fields
        private static int productId = 0;

        // Property to access private member productId  outside class
        public static int ProductId { get { return productId; } }

        // Method to get next productId
        public static int NextProductId()
        {

            return ++productId;
        }


        // Method to reset productId to zero 
        public static void Reset()
        {
            productId = 0;
        }
    }

}
