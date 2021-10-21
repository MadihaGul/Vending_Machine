using System;
using System.Collections.Generic;
using System.Text;
using Vending_Machine.Models;

namespace Vending_Machine.Data
{
    public class ProductItems
    {
        // Created and instantiated Product array to keep all products in a single collection
        private static Product[] productsCollection = new Product[0];
        public static Product[] ProductsCollection { get { return productsCollection; } }
        // Returns size of array 
        public int Size()
        {
            return productsCollection.Length;
        }

        
        // Expands array ProductCollection 
        public static Product[] AddToProductsCollection(Product product)
        {

            // Expands array to accomodate newly created object

            Array.Resize(ref productsCollection, productsCollection.Length + 1);
            productsCollection[productsCollection.Length - 1] = product;
            return productsCollection;
            
        }
       

        // Returns array to access all data within private arrTodo outside class
        public static Product[] FindAll()
        {
            return productsCollection;
        }

        // Returns specific data according to ProductId in private arrTodo outside class
        public Product FindById(int productId)
        {
            Product obProduct = null;
            try
            {
                foreach (Product item in productsCollection)
                {
                    if (item.ProductId.Equals(productId))
                        obProduct = (item);
                }

            }
            catch
            {
                Console.WriteLine("/n Exception occured while finding Product using ProductId. Contact System Admin ");
            }
            return obProduct;
        }

        // Returns specific data according to product name 
        public static Product[] FindByName(String name)
        {
            List<Product> listProduct = new List<Product>();
            try
            {
                foreach (Product item in productsCollection)
                {
                    if (item.ProductName != null)
                        if (item.ProductName.Contains(name))
                            listProduct.Add(item);
                }
                
            }
            catch
            {
                Console.WriteLine("/n Exception occured while finding Product. Contact System Admin ");
            }


            return listProduct.ToArray();
        }
        

        // Updates arrProduct by removing object from array without nulling using Product object
        public static void RemoveFromProductCollection(Product obProduct)
        {
            ProductItems ob = new ProductItems();
            try
            {
                int removeIndex = Array.IndexOf(productsCollection, obProduct);
                Array.ConstrainedCopy(productsCollection, removeIndex + 1, productsCollection, removeIndex, ob.Size() - (removeIndex + 1));
                Array.Resize(ref productsCollection, ob.Size() - 1);
            }
            catch
            {
                Console.WriteLine("/n Exception occured while removing Product items. Contact System Admin ");
            }

        }
        // Updates arrTodo by removing object from array without nulling using ProductId
        //public static void RemoveFromProductCollection(int productId)
        //{
        //    ProductItems ob = new ProductItems();
        //    try
        //    {
        //        int removeIndex = Array.IndexOf(productsCollection, ob.FindById(productId));

        //        Array.ConstrainedCopy(productsCollection, removeIndex + 1, productsCollection, removeIndex, ob.Size() - (removeIndex + 1));
        //        Array.Resize(ref productsCollection, ob.Size() - 1);
        //    }
        //    catch
        //    {
        //        Console.WriteLine("/n Exception occured while removing Product items. Contact System Admin ");
        //    }
        //}

        public void clear()
        {
            productsCollection = Array.Empty<Product>();
        }

    }
}
