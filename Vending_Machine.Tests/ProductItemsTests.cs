using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Vending_Machine.Data;
using Vending_Machine.Models;

namespace Vending_Machine.Tests
{
    public class ProductItemsTests
    {
        private ProductItems _ob = new ProductItems();
        [Fact]

        public void SizeandClearTests()
        {
            
            _ob.clear();
            Assert.Equal(0, _ob.Size());

            for (int i = 0; i < 5; i++)
            {
                Product testProduct =null;
                testProduct.ProductName = "Test" + i;
                testProduct.ProductManufacturer = "SizeandClearTests";
                testProduct.ProductPrice =Convert.ToUInt32( 10 + i);
                Product[] actualTodoItem = ProductItems.AddToProductsCollection(testProduct);                
            }
            
            Assert.Equal(5, _ob.Size());

            _ob.clear();
            Assert.Empty(ProductItems.ProductsCollection);
        }

        [Fact]

        public void AddToProductsCollectionTests()
        {
            Product[] expectedTodoItem = new Product[5];

            for (int i = 0; i < 5; i++)
            {
                Product testProduct = null;
                testProduct.ProductName = "Test" + i;
                testProduct.ProductManufacturer = "SizeandClearTests";
                testProduct.ProductPrice = Convert.ToUInt32(10 + i);
                Product[] actualTodoItem = ProductItems.AddToProductsCollection(testProduct);

                expectedTodoItem[i] = testProduct;
            }
            Assert.Equal(expectedTodoItem, ProductItems.ProductsCollection);
           
        }

        [Fact]

        public void FindTests()
        {
           
            Product[] expectedTodoItem = new Product[5];

            for (int i = 0; i < 5; i++)
            {
                Product testProduct = null;
                testProduct.ProductName = "Test" + i;
                testProduct.ProductManufacturer = "FindTests";
                testProduct.ProductPrice = Convert.ToUInt32(10 + i);
                Product[] actualTodoItem = ProductItems.AddToProductsCollection(testProduct);

                expectedTodoItem[i] = testProduct;
            }

            Assert.Equal(ProductItems.ProductsCollection, ProductItems.FindAll());


            Assert.Equal(ProductItems.ProductsCollection[1], _ob.FindById(2));


            _ob.clear();
            Assert.Empty(ProductItems.ProductsCollection);
        }

        [Fact]

        public void RemoveFromProductsCollectionTests()
        {
            
            _ob.clear();
            Random rand = new Random();
            int removeIndex =rand.Next(0,3);
            Product[] removeItem = new Product[1];
            Product[] expectedProductItem = new Product[2];

            for (int i = 0; i < 3; i++)
            {
                Product testProduct = null;
                testProduct.ProductName = "Test" + i;
                testProduct.ProductManufacturer = "RemoveTests";
                testProduct.ProductPrice = Convert.ToUInt32(10 + i);
                Product[] actualTodoItem = ProductItems.AddToProductsCollection(testProduct);
                if (removeIndex == i)
                { removeItem[0] = testProduct; }              
            }
            Array.ConstrainedCopy(ProductItems.ProductsCollection, 0, expectedProductItem, 0, removeIndex );
            Array.ConstrainedCopy(ProductItems.ProductsCollection, removeIndex + 1, expectedProductItem, removeIndex, ProductItems.ProductsCollection.Length - (removeIndex+1));

            ProductItems.RemoveFromProductCollection(removeItem[0]);

            Assert.Equal(expectedProductItem, ProductItems.ProductsCollection);
        }

       
    }
}
