using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shipnet.Contracts;
using Shipnet.Data;
using Shipnet.Models.Resources;

namespace Shipnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet(Name =nameof(GetAllCustomers))]
        public IActionResult GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        // Get /customers/{customerId}
        [HttpGet("{customerId}", Name = nameof(GetCustomerById))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Customer>> GetCustomerById(long customerId)
        {
            var customer = await customerService.GetCustomerByIdAsync(customerId);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}