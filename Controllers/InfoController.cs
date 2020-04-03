using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shipnet.Models.Resources;

namespace Shipnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly ConfigInfo configInfo;

        public InfoController(IOptions<ConfigInfo> info)
        {
            this.configInfo = info.Value;
        }

        [HttpGet(Name =nameof(GetInfo))]
        [ProducesResponseType(200)]
        public ActionResult<ConfigInfo> GetInfo()
        {
            configInfo.Href = Url.Link(nameof(GetInfo), null);
            return configInfo;
        }
    }
}