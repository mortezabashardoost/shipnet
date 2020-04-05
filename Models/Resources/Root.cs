using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipnet.Models.Resources
{
    public class Root : Resource
    {
            public Link Info { get; set; }

            public Link Customers { get; set; }
    }
}
