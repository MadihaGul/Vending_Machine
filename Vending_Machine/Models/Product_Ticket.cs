using System;
using System.Collections.Generic;
using System.Text;
using Vending_Machine.Data;

namespace Vending_Machine.Models
{
    public class Product_Ticket : Product
    {
        //private readonly int product_DrinkId;
        //public int Product_DrinkId { get { return product_DrinkId; } }
        protected uint AvailableQuantity { get; set; }

        const string basicProductInfo = "\nTicket\n";

        public Product_Ticket(int productId, string productManufacturer, string productName, uint productPrice, string productContainsInfo, uint availableQuantity)
                        : base(productId, productManufacturer, productName, productPrice)
        {
            ProductInfo = $"{basicProductInfo}{productContainsInfo}";
            AvailableQuantity = availableQuantity;
        }

        public override Product NewProduct(string productManufacturer, string productName, uint productPrice, string productContainsInfo, uint availableQuantity)
        {
            var newProduct = new Product_Ticket(ProductIdSequencer.NextProductId(), productManufacturer, productName, productPrice, productContainsInfo, availableQuantity);
            ProductItems.AddToProductsCollection(newProduct);
            return newProduct;

        }
        public new string UseProduct()
        {
            return $"\nCollect the ticket."+ base.UseProduct();

        }
    }
}
