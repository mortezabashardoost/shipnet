using Shipnet.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipnet.Contracts
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerByIdAsync(long id);
    }
}
