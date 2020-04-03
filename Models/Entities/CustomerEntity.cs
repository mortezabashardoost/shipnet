using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shipnet.Models.Entities
{
    public class CustomerEntity
    {
        [Key]
        public long CustomerId { get; set; }

        public long LoginId { get; set; }

        public string CustomerName { get; set; }

        public string MobileNo { get; set; }

    }
}
