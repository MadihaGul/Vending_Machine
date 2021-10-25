using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Vending_Machine.Data;
using Vending_Machine.Models;

namespace Vending_Machine.Tests
{
    
    public class IVendingTest
    {
        private VendingMachine vm = new VendingMachine();

        [Fact]
        public void ShowAllTests()
        {
            ProductItems ob = new ProductItems();

            ProductIdSequencer.Reset();
            ProductItems.Clear();
            Assert.Empty(ProductItems.ProductsCollection);

            Product[] expResult = new Product[3];

            for (int i = 0; i < 3; i++)
            {
                Product_Drink testProduct = new Product_Drink(ProductIdSequencer.NextProductId(), "showProductCollection", $"VTest {i}", 25, "fruits", 10);
                expResult[i] = testProduct;
                Product[] testCollection = ProductItems.AddToProductsCollection(testProduct);

            }

           Product[] actualResult = vm.ShowAll();

            Assert.Equal(expResult, actualResult);
            ProductItems.Clear();
            Assert.Empty(ProductItems.ProductsCollection);
        }
        [Fact]
        public void PurchasedTests()
        {
            Product_Drink testProduct = new Product_Drink(ProductIdSequencer.NextProductId(), "testProductCollection", $"PTest", 25, "fruits", 10);
            Product[] testCollection = ProductItems.AddToProductsCollection(testProduct);

            string expectedMsg = $"\nAmount added to moneypool. Total= 100 Kr";
            uint expectedMoneyPool = 100;

            string actualMsg = vm.InsertMoney(100);
            
            Assert.Equal(expectedMsg, actualMsg);

            Assert.Equal(expectedMoneyPool, Payment.MoneyPool);

            string msg = vm.Purchase(testProduct, out bool charged);
            Assert.True(charged);
            Assert.Equal($"\nPayment successfull\nDrink the drink.\nEnjoy PTest!",msg);
           
            
            Product_Snack testProduct2 = new Product_Snack(ProductIdSequencer.NextProductId(), "tests", $"ChocoTest", 75, "almonds", 10);
            Product[] testCollection2 = ProductItems.AddToProductsCollection(testProduct2);

            string msg2 = vm.Purchase(testProduct2, out bool charged2);
            Assert.True(charged2);
            Assert.Equal($"\nPayment successfull\nEat the snack.\nEnjoy ChocoTest!", msg2);


            Product_Snack testProduct3 = new Product_Snack(ProductIdSequencer.NextProductId(), "tests", $"ChocoTest", 75, "almonds", 10);
            Product[] testCollection3 = ProductItems.AddToProductsCollection(testProduct3);

            string msg3 = vm.Purchase(testProduct3, out bool charged3);
            Assert.False(charged3);
            Assert.Equal($"\nSorry! Not enough money to buy. Insert money", msg3);
            Assert.Equal(Convert.ToUInt32(0), Payment.MoneyPool);

            Payment.ResetMoneyPool();

            ProductIdSequencer.Reset();
            ProductItems.Clear();
        }

       
    }
}
