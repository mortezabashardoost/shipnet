using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipnet.Models.Resources
{
    public class Customer : Resource
    {
        public string CustomerName { get; set; }

        public string MobileNo { get; set; }
    }
}
