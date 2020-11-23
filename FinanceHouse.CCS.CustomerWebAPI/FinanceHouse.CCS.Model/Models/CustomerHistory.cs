using System;
using System.Collections.Generic;

#nullable disable

namespace FinanceHouse.CCS.Model
{
    public partial class CustomerHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CustomerType { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
        public int? AuditId { get; set; }

        public virtual Audit Audit { get; set; }
    }
}
