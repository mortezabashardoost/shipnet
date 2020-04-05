using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Shipnet.Models
{
    public class Link
    {
        private const string GetMethod = "GET";

        public static Link To(string routeName, object routeValues = null)
            => new Link
            {
                RouteName = routeName,
                RouteValues = routeValues,
                Relations = null,
                Method = GetMethod
            };
        

        [JsonProperty(Order = -4)]
        public string Href { get; set; }

        [JsonProperty(Order = -3, PropertyName = "rel", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Relations { get; set; }

        [JsonProperty(Order = -2, NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue(GetMethod)]
        public string Method { get; set; }

        // stores the route name before being rewritten be LinkRewritingFilter
        [JsonIgnore]
        public string RouteName { get; set; }

        // stores the route parameters before being rewritten be LinkRewritingFilter
        [JsonIgnore]
        public object RouteValues { get; set; }
    }
}
