using FinanceHouse.CCS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace FinanceHouse.CCS.ServiceLayer.Concrete
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Customer, CustomerHistory>(); // means you want to map from User to UserDTO
        }
    }
}
