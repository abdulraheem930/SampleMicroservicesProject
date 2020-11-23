using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceHouse.CCS.Model;
using FinanceHouse.CCS.Model.Models;
using FinanceHouse.CCS.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace FinanceHouse.CCS.CustomerWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private ICustomerServiceLayer _customerServiceLayer;
        private readonly ILogger _logger;
        private readonly IMemoryCache _cache;
        public CustomerController(ICustomerServiceLayer customerServiceLayer, ILogger<CustomerController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _customerServiceLayer = customerServiceLayer;
            _cache = memoryCache;
        }

        [HttpGet("GetCustomer/{customerId}")]


        public ActionResult GetCustomer(string customerId)
        {
            try
            {
                var customer = new Customer();
                if (!_cache.TryGetValue<Customer>(customerId, out customer))
                {
                    var result = _customerServiceLayer.GetCustomer(customerId);

                    _cache.Set<Customer>(customerId, result);
                    return Ok(result);
                }
                else
                {

                    return Ok(customer);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }



        }

        [HttpPost("CreateCustomer")]
        public ActionResult CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                _logger.LogInformation("Creating customer " + customer.Name);
                var result = _customerServiceLayer.CreateCustomer(customer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }

        }

        [HttpDelete("DeleteCustomer/{userid}")]
        public ActionResult DeleteCustomer(string userid)
        {
            try
            {
                _logger.LogInformation("Deleting a customer " + userid);
                var result = _customerServiceLayer.DeleteCustomer(userid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }

        }

        [HttpPut("UpdateCustomer")]
        public ActionResult UpdateCustomer([FromBody] Customer customer, string userId)
        {
            try
            {
                _logger.LogInformation("Updating a customer " + customer);
                var result = _customerServiceLayer.UpdateCustomer(customer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }

        }


    }
}