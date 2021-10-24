using System;
using System.Collections.Generic;
using System.Text;
using Vending_Machine.Data;
namespace Vending_Machine.Models
{
    public interface IVending
    {

        string EndTransaction();

        Product[] SearchProducts(string searchProduct);
        Product[] ShowAll();

        string InsertMoney(uint amount);
        string Purchase(Product purchaseProduct, out bool charged);


    }
}
