using Microsoft.EntityFrameworkCore;
using Shipnet.Contracts;
using Shipnet.Data;
using Shipnet.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipnet.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ShipnetDbContext context;

        public CustomerService(ShipnetDbContext context)
        {
            this.context = context;
        }
        public async Task<Customer> GetCustomerByIdAsync(long id)
        {
            var foundCustomer = await context.Customers.SingleOrDefaultAsync(c => c.CustomerId == id);

            if (foundCustomer == null)
            {
                return null;
            }

            return new Customer
            {
                Href = null,
                CustomerName = foundCustomer.CustomerName,
                MobileNo = foundCustomer.MobileNo
            };

        }
    }
}
