using FinanceHouse.CCS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinanceHouse.CCS.BusinessLayer.Interface
{
    public interface ICustomerBusinessLayer
    {
        IQueryable<Customer> QueryCustomer();
        IEnumerable<Customer> GetCustomer();
        Customer GetCustomer(int Id);
        Customer GetCustomer(string userId);
        Customer InsertCustomer(Customer Customer);
        Customer UpdateCustomer(Customer Customer);
        bool DeleteCustomer(string Id);
    }
}
