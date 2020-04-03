using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipnet.Models.Resources
{
    public class ConfigInfo : Resource
    {
        public string ServerName { get; set; }
        public string ServerTimeZone { get; set; }
    }
}
