using Microsoft.EntityFrameworkCore;
using Shipnet.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipnet.Data
{
    public class ShipnetDbContext : DbContext
    {
        public ShipnetDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<CustomerEntity> Customers { get; set; }
    }
}
