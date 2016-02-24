using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5EntityTest.Middleware
{
    public class RequestLoggerMiddleware
    {
        private RequestDelegate _next;
        private ILoggerFactory _loggerFactory;

        public RequestLoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _loggerFactory = loggerFactory;
        }

        public async Task Invoke(HttpContext context)
        {
            ILogger logger = _loggerFactory.CreateLogger<RequestLoggerMiddleware>();
            logger.LogInformation("Logger: Request started: " + context.Request.Path);
            await _next.Invoke(context);
            logger.LogInformation("Logger: Request finished");
        }
    }
}
