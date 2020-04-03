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
        [ProducesResponseType(200)]
        public IActionResult GetRoot()
        {
            var response = new
            {
                href = Url.Link(nameof(GetRoot),null),
                customers = new
                {
                    href = Url.Link(nameof(CustomersController.GetAllCustomers),null)
                },
                info = new
                {
                    href = Url.Link(nameof(InfoController.GetInfo),null)
                }
            };
            return Ok(response);
        }
    }
}