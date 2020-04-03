using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Shipnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipnet.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment hostingEnvironment;

        public JsonExceptionFilter(IHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        public void OnException(ExceptionContext context)
        {
            var error = new ApiError();

            if (hostingEnvironment.IsDevelopment())
            {
                error.Message = context.Exception.Message;
                error.Detail = context.Exception.StackTrace;
            }
            else
            {
                error.Message = "A Server error encountered";
                error.Detail = context.Exception.Message;
            }

            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };
        }
    }
}
