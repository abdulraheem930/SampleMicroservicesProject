using FinanceHouse.CCS.Model;

using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceHouse.CCS.ServiceLayer.Interfaces
{
    public interface ICustomerServiceLayer
    {
        Customer GetCustomer(string userId);
        Customer CreateCustomer(Customer customer);
        bool DeleteCustomer(string userId);
        Customer UpdateCustomer(Customer customer);
    }
}
