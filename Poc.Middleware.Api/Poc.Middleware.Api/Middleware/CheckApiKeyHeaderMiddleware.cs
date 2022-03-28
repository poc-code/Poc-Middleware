using Poc.Middleware.Api.Domain.Response;
using Poc.Middleware.Api.Service;

namespace Poc.Middleware.Api.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CheckApiKeyHeaderMiddleware
    {
        private readonly CredentialService _service;
        private readonly RequestDelegate _next;

        public CheckApiKeyHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
            _service = new CredentialService();
        }

        public Task Invoke(HttpContext httpContext)
        {
            try
            {
                #region request
                string customHeader = string.Empty;
                if (httpContext.Request.Headers.TryGetValue("x-api-key", out var traceValue))
                {
                    customHeader = traceValue;
                }
                var check = _service.GetById(customHeader);

                if (check is null)
                {
                    var objResponse = new ResponseDefaultModel
                    {
                        Error = "Unauthorized",
                        Message = "Cliente não autorizado"
                    };

                    return httpContext.Response.WriteAsJsonAsync(objResponse);
                }

                #endregion

                return _next(httpContext);
               
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CheckApiKeyHeaderMiddlewareExtensions
    {
        public static IApplicationBuilder UseCheckApiKeyHeaderMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckApiKeyHeaderMiddleware>();
        }
    }
}
