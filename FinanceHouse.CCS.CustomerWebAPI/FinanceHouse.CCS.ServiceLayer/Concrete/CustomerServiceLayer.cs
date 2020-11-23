using AutoMapper;
using FinanceHouse.CCS.BusinessLayer.Interface;
using FinanceHouse.CCS.Model;
using FinanceHouse.CCS.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceHouse.CCS.ServiceLayer.Concrete
{
    public class CustomerServiceLayer : ICustomerServiceLayer
    {
        private ICustomerBusinessLayer _customerBusinessLayer;
        private IAuditBusinessLayer _auditBusinessLayer;
        private ICustomerHistoryBusinessLayer _customerHistoryBusinessLayer;
        private readonly IMapper _mapper;
        public CustomerServiceLayer(ICustomerBusinessLayer customerBusinessLayer,IAuditBusinessLayer auditBusinessLayer, IMapper mapper,ICustomerHistoryBusinessLayer customerHistoryBusinessLayer)
        {
            _customerBusinessLayer = customerBusinessLayer;
            _mapper = mapper;
            _customerHistoryBusinessLayer = customerHistoryBusinessLayer;
            _auditBusinessLayer = auditBusinessLayer;
        }
        public Customer CreateCustomer(Customer customer)
        {
            customer.CreatedDate = DateTime.UtcNow;
            customer.ModifiedDate = DateTime.UtcNow;
           return  _customerBusinessLayer.InsertCustomer(customer);
        }

        public bool DeleteCustomer(string userId)
        {
            return _customerBusinessLayer.DeleteCustomer(userId);
        }

        public Customer GetCustomer(string userId)
        {
            return _customerBusinessLayer.GetCustomer(userId);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            customer.ModifiedDate = DateTime.UtcNow;
            var customerResult = _customerBusinessLayer.UpdateCustomer(customer);
            var audit = new Audit(){ AffectedOn = DateTime.UtcNow,UserId = customerResult.Id,Comment = "New updation" };
            audit = _auditBusinessLayer.InsertAudit(audit);
            var customerHistory = _mapper.Map<CustomerHistory>(customerResult);
            customerHistory.AuditId = audit.Id;
            customerHistory.Id = 0;
            _customerHistoryBusinessLayer.InsertCustomerHistory(customerHistory);


            //var customerHistory = new CustomerHistory() { }
            return customerResult;
        }
    }
}
