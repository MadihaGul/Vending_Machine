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
        public ProductItemsTests()
        {
            ProductIdSequencer.Reset();
        }

        private ProductItems _ob = new ProductItems();
        [Fact]

        public void SizeandClearTests()
        {
            
            ProductItems.Clear();
            Assert.Equal(0, _ob.Size());

            for (int i = 0; i < 5; i++)
            {
                Product_Drink testProduct = new Product_Drink(ProductIdSequencer.NextProductId(), "testProductCollection", $"SCTest+{i}", 25, "fruits", 10);
                Product[] test = ProductItems.AddToProductsCollection(testProduct);
            }
            
            Assert.Equal(5, _ob.Size());

            ProductItems.Clear();
            Assert.Empty(ProductItems.ProductsCollection);
        }

        [Fact]

        public void AddToProductsCollectionTests()
        {
            Product[] expectedTodoItem = new Product[5];

            for (int i = 0; i < 5; i++)
            {
                
                switch(i)
                {
                    case 0: 
                        {
                            Product_Drink testProduct = new Product_Drink(ProductIdSequencer.NextProductId(), "DrinkProductCollection", $"AddTest+{i}", 25, "fruits", 10);
                            Product[] test = ProductItems.AddToProductsCollection(testProduct); expectedTodoItem[i] = testProduct;
                            break;
                        }
                    case 1: 
                        {
                            Product_Snack testProduct = new Product_Snack(ProductIdSequencer.NextProductId(), "SnacktestProductCollection", $"addTest+{i}", 20, "Chocolate", 10);
                            Product[] test = ProductItems.AddToProductsCollection(testProduct); expectedTodoItem[i] = testProduct;
                            break;
                        }
                    case 2:
                        {
                            Product_Game testProduct = new Product_Game(ProductIdSequencer.NextProductId(), "GAmetestProductCollection", $"Test+{i}", 15, "Hangman", 10);
                            Product[] test = ProductItems.AddToProductsCollection(testProduct); expectedTodoItem[i] = testProduct; break;
                        }
                    case 3:
                        {
                            Product_Card testProduct = new Product_Card(ProductIdSequencer.NextProductId(), "CardtestProductCollection", $"Test+{i}", 10, "Vendo", 15);
                            Product[] test = ProductItems.AddToProductsCollection(testProduct); expectedTodoItem[i] = testProduct; break;
                        }
                    case 4:
                        {
                            Product_Ticket testProduct = new Product_Ticket(ProductIdSequencer.NextProductId(), "TickettestProductCollection", $"Test+{i}", 34, "VästTrafik", 10);
                            Product[] test = ProductItems.AddToProductsCollection(testProduct); expectedTodoItem[i] = testProduct; break;
                        }
                    default:
                        {
                            Product_Ticket testProduct = new Product_Ticket(ProductIdSequencer.NextProductId(), "TickettestProductCollection", $"Test+{i}", 34, "VästTrafik", 10);
                            Product[] test = ProductItems.AddToProductsCollection(testProduct); expectedTodoItem[i] = testProduct; break;
                        }

                }
                     

                
            }
            Assert.Equal(expectedTodoItem, ProductItems.ProductsCollection);
            ProductItems.Clear();
            Assert.Empty(ProductItems.ProductsCollection);

        }

        [Fact]

        public void FindTests()
        {
           
            Product[] expectedTodoItem = new Product[5];

            for (int i = 0; i < 5; i++)
            {
                Product_Drink testProduct = new Product_Drink(ProductIdSequencer.NextProductId(), "testProductCollection", $"findTest+{i}", 25, "fruits", 10);
                Product[] test = ProductItems.AddToProductsCollection(testProduct);

                expectedTodoItem[i] = testProduct;
            }

            Assert.Equal(ProductItems.ProductsCollection, ProductItems.FindAll());


            Assert.Equal(ProductItems.ProductsCollection[1], _ob.FindById(2));


            ProductItems.Clear();
            Assert.Empty(ProductItems.ProductsCollection);
        }

        [Fact]

        public void RemoveFromProductsCollectionTests()
        {
            
            ProductItems.Clear();
            Random rand = new Random();
            int removeIndex =rand.Next(0,3);
            Product[] removeItem = new Product[1];
            Product[] expectedProductItem = new Product[2];

            for (int i = 0; i < 3; i++)
            {
                Product_Drink testProduct = new Product_Drink(ProductIdSequencer.NextProductId(), "testProductCollection", $"removeTest+{i}", 25, "fruits", 10);
                Product[] test = ProductItems.AddToProductsCollection(testProduct);

                if (removeIndex == i)
                { removeItem[0] = testProduct; }              
            }
            Array.ConstrainedCopy(ProductItems.ProductsCollection, 0, expectedProductItem, 0, removeIndex );
            Array.ConstrainedCopy(ProductItems.ProductsCollection, removeIndex + 1, expectedProductItem, removeIndex, ProductItems.ProductsCollection.Length - (removeIndex+1));

            ProductItems.RemoveFromProductCollection(removeItem[0]);

            Assert.Equal(expectedProductItem, ProductItems.ProductsCollection);

            ProductItems.Clear();
            Assert.Empty(ProductItems.ProductsCollection);
        }

       
    }
}
