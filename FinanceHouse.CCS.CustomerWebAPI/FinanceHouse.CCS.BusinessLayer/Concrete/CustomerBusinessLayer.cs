using FinanceHouse.CCS.BusinessLayer.Interface;
using FinanceHouse.CCS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xavor.SD.Repository.Contracts.UnitOfWork;
using Xavor.SD.Repository.Interfaces;

namespace FinanceHouse.CCS.BusinessLayer.Concrete
{
  public  class CustomerBusinessLayer: ICustomerBusinessLayer
    {

        private readonly IUnitOfWork _uow;
        private IRepository<Customer> _repo;
        public CustomerBusinessLayer(IUnitOfWork uow)
        {
            _uow = uow;
            _repo = uow.GetRepository<Customer>();
        }

        public IQueryable<Customer> QueryCustomer()
        {
            
            try
            {
                return _repo.Queryable();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Customer> GetCustomer()
        {
            try
            {
                return _repo.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer GetCustomer(int Id)
        {
            try
            {
                if (Id <= default(int))
                    throw new ArgumentException("Invalid id");
                return _repo.Find(Id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Customer GetCustomer(string userId)
        {
            var Customer = QueryCustomer().Where(x => x.UserId == userId).FirstOrDefault();
            return Customer;
        }

        public Customer InsertCustomer(Customer Customer)
        {
            try
            {
                _repo.Add(Customer);
                _uow.SaveChanges();

                return Customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer UpdateCustomer(Customer customer)
        {
            try
            {
                _repo.Update(customer);
                _uow.SaveChanges();
                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteCustomer(string CustomerId)
        {
            try
            {
                var Customer = QueryCustomer().Where(x => x.UserId == CustomerId).FirstOrDefault();
                _repo.Delete(Customer.Id);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
