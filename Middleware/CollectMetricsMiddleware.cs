using Microsoft.AspNetCore.Http;
using Strona.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strona.Middleware
{
    public class CollectMetricsMiddleware
    {
        private readonly RequestDelegate _next;

        public CollectMetricsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IMetricsCollector collector)
        {
            await _next(context);

            collector.Collect(context.Request.Method, context.Request.Path, context.Response.StatusCode);
        }
    }
}
