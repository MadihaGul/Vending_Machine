using System;
using System.Collections.Generic;
using System.Text;
using Vending_Machine.Data;

namespace Vending_Machine.Models
{
    public abstract class Product: IVending
    {
        // Created common fields and properties
        private readonly int productId;
        public int ProductId { get { return productId; } }
        protected string productName;
        protected string productManufacturer;
        protected uint productPrice;
        public uint ProductPrice
        {
            get
            { return productPrice; }
            set
            {
                if (productPrice<=0)
                {
                    throw new ArgumentException("Product price must not be zero.");
                }
                productPrice = value;
            }
        }
        
        public string ProductName
        {
            get
            { return productName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Product name must have a value.");
                }
                productName = value;
            }
        }

        public string ProductManufacturer
        {
            get
            { return productManufacturer; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Product manufacturer must have a value.");
                }
                productManufacturer = value;
            }
        }
        protected string ProductInfo { get; set; }

        //protected int AvailableProductCount { get; set; }
        //public bool ProductAvailable { get; set; }
        //protected DateTime DateProductSold{ get; set; }

        // Common method to examine product details

        public void ExamineProduct(Product product)
        {
            Console.WriteLine($"{product.ProductManufacturer}\t{product.ProductName}\n Information:\t{product.ProductInfo}\nPrice:\t{product.ProductPrice}");
        }
        // Common method to use product 
        public string UseProduct()
        {
            return $"\nEnjoy {ProductName}!";

        }
        public string EndTransaction()//UI
        {
            
            string message = UseProduct();
            IVending.stopService = true;
            return message;
        }
        // Creates a new Product object and adds in product items
        public virtual Product NewProduct(string productManufacturer, string productName, uint productPrice, string productContainsInfo, uint availableQuantity)
        {
            //To create new child object of Product by overriding
            Product newProduct = null;
            ProductItems.AddToProductsCollection(newProduct);
            return newProduct;
        }

        // Constructor
        public Product(int productId,string productManufacturer, string productName, uint productPrice) 
        {
            this.productId = productId;
            ProductManufacturer = productManufacturer;
            ProductName = productName;
           // ProductInfo = productInfo;
            ProductPrice = productPrice;
        }

      
    }
}
