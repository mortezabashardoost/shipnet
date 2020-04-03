using Microsoft.Extensions.DependencyInjection;
using Shipnet.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipnet.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            await AddTestData(services.GetRequiredService<ShipnetDbContext>());
        }

        public static async Task AddTestData(ShipnetDbContext context)
        {
            if (context.Customers.Any())
            {
                // Already has data
                return;
            }

            context.Customers.Add(new CustomerEntity
            {
                CustomerId = 1,
                LoginId = 1,
                CustomerName = "Morteza",
                MobileNo = "001128283122"
            });

            context.Customers.Add(new CustomerEntity
            {
                CustomerId = 2,
                LoginId = 2,
                CustomerName = "Narges",
                MobileNo = "43318793289"
            });

            context.Customers.Add(new CustomerEntity
            {
                CustomerId = 3,
                LoginId = 3,
                CustomerName = "Frank",
                MobileNo = "7362873642"
            });

            await context.SaveChangesAsync();

        }
    }
}
