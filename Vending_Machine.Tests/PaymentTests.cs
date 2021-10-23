using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Vending_Machine.Data;
using Vending_Machine.Models;
namespace Vending_Machine.Tests
{
    public class PaymentTests
    {
       

        private static readonly List<uint> moneyDominations = new List<uint> { 1, 5, 10, 20, 50, 100, 500, 1000 };
        private static uint testMoneyPool ;

        private readonly Payment ob = new Payment();
        

        [Theory]
        [InlineData(0)]
        [InlineData(5000)]
        [InlineData(500)]
        [InlineData(15)]
        [InlineData(23)]
        [InlineData(10)]
        [InlineData(5)]
        [InlineData(1)]
        public void AddToMoneyPoolTests(uint amount)
        {
            string expectedMsg;
            if (moneyDominations.Contains(amount))
                testMoneyPool += amount;
            string actualMsg= ob.AddToMoneyPool(amount);

            if (amount == 500 || amount == 10 || amount == 5 || amount == 1)
                expectedMsg = $"\nAmount added to moneypool. Total= {testMoneyPool} Kr";
            else
                expectedMsg = $"\nInvalid amount.\n Acceptable denominations: 1kr, 5kr, 10kr, 20kr, 50kr, 100kr, 500kr, 1000kr";

            Assert.Equal(expectedMsg,actualMsg);
            Assert.Equal(testMoneyPool,Payment.MoneyPool);

        }
        [Theory]
     
        [InlineData(0)]        
        [InlineData(257)]
        [InlineData(2)]
        public void PayBalanceTests(uint addInMoneyPool)
        {
            string expectedMsg;
            uint[] expDenomination = new uint[0];
            string msg;

            uint[] addMoney = ob.CalculateBalanceInDenomination(addInMoneyPool);
            for (int i = 0; i < addMoney.Length; i++)
                msg= ob.AddToMoneyPool(addMoney[i]);
            if(addInMoneyPool==257)
            Assert.Equal(Convert.ToUInt32(257), Payment.MoneyPool);

            string actualMsg = ob.PayBalance(out uint[] inDenomination);
            if (addInMoneyPool == 0)
            { 
                expectedMsg = $"\nBalance: 0 Kr.";                
            }
                
            else
            {
                expectedMsg = $"\nBalance: {addInMoneyPool} Kr.";
                if (addInMoneyPool == 257)
                {
                    Array.Resize(ref expDenomination, 6);
                    expDenomination[0] = 100;
                    expDenomination[1] = 100;
                    expDenomination[2] = 50;
                    expDenomination[3] = 5;
                    expDenomination[4] = 1;
                    expDenomination[5] = 1;
                    
                }
                else
                {
                    Array.Resize(ref expDenomination,2);
                    expDenomination[0] = 1;
                    expDenomination[1] = 1;
                }

            }
                          
            Assert.Equal(expectedMsg, actualMsg);
            Assert.Equal(expDenomination, inDenomination);

            
        }
       
        [Theory]
        [InlineData(200)]
        [InlineData(257)]
        [InlineData(2)]
        public void ChargePriceTests(uint testAmount)
        {
            Payment.ResetMoneyPool();
            bool expectedCharged;
            string msg;

            uint[] addMoney = ob.CalculateBalanceInDenomination(testAmount);
            for (int i = 0; i < addMoney.Length; i++)
                msg = ob.AddToMoneyPool(addMoney[i]);


            if (testAmount == 200)
            {
                expectedCharged = ob.ChargePrice(400);
                Assert.False(expectedCharged);
                Assert.Equal(Convert.ToUInt32(200),Payment.MoneyPool);
            }
            else if (testAmount == 257)
            {
                expectedCharged = ob.ChargePrice(200);
                Assert.True(expectedCharged);
                Assert.Equal(Convert.ToUInt32(57), Payment.MoneyPool);
                

            }
            else 
            {
                expectedCharged = ob.ChargePrice(testAmount);
                Assert.True(expectedCharged);
                Assert.Equal(Convert.ToUInt32(0), Payment.MoneyPool);

            }

            Payment.ResetMoneyPool();

        }
    }
}
