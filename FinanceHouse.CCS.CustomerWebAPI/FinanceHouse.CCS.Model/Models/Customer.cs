using System;
using System.Collections.Generic;

#nullable disable

namespace FinanceHouse.CCS.Model
{
    public partial class Customer
    {
        public string Name { get; set; }
        public string CustomerType { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Createdby { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
