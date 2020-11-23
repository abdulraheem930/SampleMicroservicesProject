using FinanceHouse.CCS.BusinessLayer.Interface;
using FinanceHouse.CCS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xavor.SD.Repository.Contracts.UnitOfWork;
using Xavor.SD.Repository.Interfaces;

namespace FinanceHouse.CCS.BusinessLayer.Concrete
{
    public class AuditBusinessLayer : IAuditBusinessLayer
    {
        private readonly IUnitOfWork _uow;
        private IRepository<Audit> _repo;
        public AuditBusinessLayer(IUnitOfWork uow)
        {
            _uow = uow;
            _repo = uow.GetRepository<Audit>();
        }

        public Audit InsertAudit(Audit audit)
        {
            try
            {
                _repo.Add(audit);
                _uow.SaveChanges();

                return audit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
