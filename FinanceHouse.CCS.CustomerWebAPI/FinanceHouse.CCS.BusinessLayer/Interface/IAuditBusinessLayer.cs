using FinanceHouse.CCS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceHouse.CCS.BusinessLayer.Interface
{
    public interface IAuditBusinessLayer
    {
        Audit InsertAudit(Audit audit);
    }
}
