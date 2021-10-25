using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine.Data
{
    public class Payment
    {
        //Money should be input in fixed denominations defined as an array of integers (readonly)
        // 1kr, 5kr, 10kr, 20kr, 50kr, 100kr, 500kr and 1000kr
        private static readonly uint[] moneyDominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };
        public static uint[] MoneyDominations { get { return moneyDominations; } }
        
        private static uint moneyPool = 0;
        public static uint MoneyPool { get { return moneyPool; } }
     
        public string AddToMoneyPool(uint amount)
        {
          
            string message = $"\nInvalid amount.\n Acceptable denominations: 1kr, 5kr, 10kr, 20kr, 50kr, 100kr, 500kr, 1000kr"; 
            
            foreach (uint item in moneyDominations)
                if (item == amount)
                {
                    moneyPool += amount;
                    message= $"\nAmount added to moneypool. Total= {moneyPool} Kr";
                }
            
            return message;
        }
        public  bool ChargePrice(uint productPrice)
        {
            bool charged = false;
            if (productPrice <= moneyPool)
                {
                moneyPool -= productPrice;
                charged = true;
                }
            return charged;
        }

        public string PayBalance(out uint[] Balance)
        {
            Balance = new uint [0];
            string message = $"\nBalance: 0 Kr.";
            if ( moneyPool>0)
            {
                Balance = CalculateBalanceInDenomination(moneyPool);
                message = $"\nBalance: {moneyPool} Kr.";

                ResetMoneyPool();
            }
            return message;
        }
        public uint[] CalculateBalanceInDenomination(uint balance)
        {
            List<uint> BalanceInDenomination = new List<uint>();
            while (balance != 0)
            {
                for (int i = moneyDominations.Length-1;i>=0;i--)//uint denomination in moneyDominations
                {
                    if (balance == 0) break;
                    else
                    {
                        if (balance>=moneyDominations[i])                        
                        {

                            BalanceInDenomination.Add(moneyDominations[i]);
                            balance -= moneyDominations[i]; break;

                        }
                    }
                }
                    
            }
           
            return BalanceInDenomination.ToArray();
        }

        
        public static void ResetMoneyPool()
        { moneyPool = 0; }
    }
}
