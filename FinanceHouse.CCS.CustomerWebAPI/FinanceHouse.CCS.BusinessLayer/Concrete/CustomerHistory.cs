using FinanceHouse.CCS.BusinessLayer.Interface;
using FinanceHouse.CCS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xavor.SD.Repository.Contracts.UnitOfWork;
using Xavor.SD.Repository.Interfaces;

namespace FinanceHouse.CCS.BusinessLayer.Concrete
{
    public class CustomerHistoryBusinessLayer : ICustomerHistoryBusinessLayer
    {
        private readonly IUnitOfWork _uow;
        private IRepository<CustomerHistory> _repo;
        public CustomerHistoryBusinessLayer(IUnitOfWork uow)
        {
            _uow = uow;
            _repo = uow.GetRepository<CustomerHistory>();
        }
        public CustomerHistory InsertCustomerHistory(CustomerHistory customerHistory)
        {
            try
            {
                _repo.Add(customerHistory);
                _uow.SaveChanges();

                return customerHistory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
