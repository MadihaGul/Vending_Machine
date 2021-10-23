using System;
using System.Collections.Generic;
using System.Text;
using Vending_Machine.Data;
namespace Vending_Machine.Models
{
    public class Product_Game:Product
    {
       // private readonly int product_DrinkId;
        //public int Product_DrinkId { get { return product_DrinkId; } }
        protected uint AvailableQuantity { get; set; }

        const string basicProductInfo = "\nGame\n";

        public Product_Game(int productId, string productManufacturer, string productName, uint productPrice, string productContainsInfo, uint availableQuantity)
                        : base(productId, productManufacturer, productName, productPrice)
        {
            ProductInfo = $"{basicProductInfo}{productContainsInfo}";
            AvailableQuantity = availableQuantity;
        }

        public override Product NewProduct(string productManufacturer, string productName, uint productPrice, string productContainsInfo, uint availableQuantity)
        {
            var newProduct = new Product_Game(ProductIdSequencer.NextProductId(), productManufacturer, productName, productPrice, productContainsInfo, availableQuantity);
            ProductItems.AddToProductsCollection(newProduct);
            return newProduct;

        }
        public new string UseProduct()
        {
            return $"\nPlay the game." + base.UseProduct();
        }
    }
}
