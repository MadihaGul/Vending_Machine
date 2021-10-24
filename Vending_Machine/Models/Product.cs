using System;
using System.Collections.Generic;
using System.Text;
using Vending_Machine.Data;

namespace Vending_Machine.Models
{
    public abstract class Product
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
                if (value <= 0)
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

        public virtual Product NewProduct(string productManufacturer, string productName, uint productPrice, string productContainsInfo, uint availableQuantity)
        {
            Product newProduct = null;
            return newProduct;
        }
        public static string ExamineProduct(Product product)
        { 
            string message="";
            if (product is Product_Drink)
                message = $"{product.ProductManufacturer}\t{product.ProductName}\nInformation:\t{(product as Product_Drink).ProductInfo}\nPrice:\t{(product as Product_Drink).ProductPrice} Kr"; 
            else if (product is Product_Snack)
                message = $"{product.ProductManufacturer}\t{product.ProductName}\nInformation:\t{(product as Product_Snack).ProductInfo}\nPrice:\t{(product as Product_Snack).ProductPrice} Kr";
            else if (product is Product_Ticket)        
                message = $"{product.ProductManufacturer}\t{product.ProductName}\nInformation:\t{(product as Product_Ticket).ProductInfo}\nPrice:\t{(product as Product_Ticket).ProductPrice} Kr";
            else if (product is Product_Card)
                message = $"{product.ProductManufacturer}\t{product.ProductName}\nInformation:\t{(product as Product_Card).ProductInfo}\nPrice:\t{(product as Product_Card).ProductPrice} Kr";
            else if (product is Product_Game)
                message = $"{product.ProductManufacturer}\t{product.ProductName}\nInformation:\t{(product as Product_Game).ProductInfo}\nPrice:\t{(product as Product_Game).ProductPrice} Kr";

            return message;
        }
        // Common method to use product 
        public string UseProduct()
        {
            return $"\nEnjoy {ProductName}!";

        }
      
        // Creates a new Product object and adds in product items

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
