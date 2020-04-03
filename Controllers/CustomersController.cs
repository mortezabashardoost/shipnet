﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shipnet.Data;
using Shipnet.Models.Resources;

namespace Shipnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ShipnetDbContext context;

        public CustomersController(ShipnetDbContext context)
        {
            this.context = context;
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
            var foundCustomer = await context.Customers.SingleOrDefaultAsync(c => c.CustomerId == customerId);

            if (foundCustomer == null)
            {
                return NotFound();
            }

            var resource = new Customer
            {
                Href = Url.Link(nameof(GetCustomerById), new { customerId = foundCustomer.CustomerId }),
                CustomerName = foundCustomer.CustomerName,
                MobileNo = foundCustomer.MobileNo
            };

            return Ok(resource);
        }
    }
}