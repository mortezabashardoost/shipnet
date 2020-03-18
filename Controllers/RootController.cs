using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shipnet.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet(Name =nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new
            {
                href = Url.Link(nameof(GetRoot),null)
            };
            return Ok(response);
        }
    }
}