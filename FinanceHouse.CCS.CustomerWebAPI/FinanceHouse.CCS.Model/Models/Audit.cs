using System;
using System.Collections.Generic;

#nullable disable

namespace FinanceHouse.CCS.Model
{
    public partial class Audit
    {
        public Audit()
        {
            CustomerHistories = new HashSet<CustomerHistory>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? AffectedOn { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<CustomerHistory> CustomerHistories { get; set; }
    }
}
