using System;
using Xunit;
using Vending_Machine.Models;
using Vending_Machine.Data;

namespace Vending_Machine.Tests
{
    public class ProductTests
    {
        [Fact]

        public void ExamineTests()
        {
            ProductItems ob = new ProductItems();

            ProductItems.Clear();
            Assert.Empty(ProductItems.ProductsCollection);

            Product[] expectedTodoItem = new Product[5];

            for (int i = 0; i < 5; i++)
            {

                switch (i)
                {
                    case 0:
                        {
                            Product_Drink testProduct = new Product_Drink(ProductIdSequencer.NextProductId(), "Drinki", $"ExamineTest+{i}", 25, "fruits Juice with Apple and Grapes", 10);
                            Product[] test = ProductItems.AddToProductsCollection(testProduct); expectedTodoItem[i] = testProduct;
                            break;
                        }
                    case 1:
                        {
                            Product_Snack testProduct = new Product_Snack(ProductIdSequencer.NextProductId(), "SnackCollection", $"ExamineTest+{i}", 20, "Chocolate with almonds", 7);
                            Product[] test = ProductItems.AddToProductsCollection(testProduct); expectedTodoItem[i] = testProduct;
                            break;
                        }
                    case 2:
                        {
                            Product_Game testProduct = new Product_Game(ProductIdSequencer.NextProductId(), "GAmeLand", $"ExamineTest+{i}", 15, "Hangman", 1);
                            Product[] test = ProductItems.AddToProductsCollection(testProduct); expectedTodoItem[i] = testProduct; break;
                        }
                    case 3:
                        {
                            Product_Card testProduct = new Product_Card(ProductIdSequencer.NextProductId(), "CardsAB", $"ExamineTest+{i}", 10, "Vendo Vending Machine card for easy payments", 15);
                            Product[] test = ProductItems.AddToProductsCollection(testProduct); expectedTodoItem[i] = testProduct; break;
                        }
                    case 4:
                        {
                            Product_Ticket testProduct = new Product_Ticket(ProductIdSequencer.NextProductId(), "TicketsAB", $"ExamineTest+{i}", 34, "VästTrafik Travel Ticket Single Zone-A/Zone-B", 30);
                            Product[] test = ProductItems.AddToProductsCollection(testProduct); expectedTodoItem[i] = testProduct; break;
                        }
                    default:
                        {
                            Product_Ticket testProduct = new Product_Ticket(ProductIdSequencer.NextProductId(), "TicketsAB", $"ExamineTest+{i}", 34, "VästTrafik Travel Ticket Single Zone-A/Zone-B", 30);
                            Product[] test = ProductItems.AddToProductsCollection(testProduct); expectedTodoItem[i] = testProduct; break;
                        }

                }


            }
            Assert.Equal(expectedTodoItem, ProductItems.ProductsCollection);

            string DrinkMsg = Product.ExamineProduct(expectedTodoItem[0]);
            string SnackMsg = Product.ExamineProduct(expectedTodoItem[1]);
            string GamekMsg = Product.ExamineProduct(expectedTodoItem[2]);
            string TicketMsg = Product.ExamineProduct(expectedTodoItem[4]);
            string CardMsg = Product.ExamineProduct(expectedTodoItem[3]);

            Assert.Equal($"Drinki\tExamineTest+0\nInformation:\t\nDrink\nfruits Juice with Apple and Grapes\nPrice:\t25 Kr", DrinkMsg);
            Assert.Equal($"SnackCollection\tExamineTest+1\nInformation:\t\nSnack\nChocolate with almonds\nPrice:\t20 Kr", SnackMsg);
            Assert.Equal($"GAmeLand\tExamineTest+2\nInformation:\t\nGame\nHangman\nPrice:\t15 Kr", GamekMsg);
            Assert.Equal($"TicketsAB\tExamineTest+4\nInformation:\t\nTicket\nVästTrafik Travel Ticket Single Zone-A/Zone-B\nPrice:\t34 Kr", TicketMsg);
            Assert.Equal($"CardsAB\tExamineTest+3\nInformation:\t\nCard\nVendo Vending Machine card for easy payments\nPrice:\t10 Kr", CardMsg);

            

            ProductItems.Clear();
            Assert.Empty(ProductItems.ProductsCollection);

        }




    }
}
