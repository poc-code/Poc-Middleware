using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Poc.Middleware.Api.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ErrorHandlerMiddleware(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task Invoke(HttpContext context)
        {
            var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;

            if (ex == null)
            {
                return;
            }

            var problemDetails = new ProblemDetails
            {
                Title = "Internal Server Error",
                Status = StatusCodes.Status500InternalServerError,
                Instance = context.Request.Path.Value,
                Detail = ex.InnerException is null ?
                    $"{ex.Message}" :
                    $"{ex.Message} | {ex.InnerException}"
            };

            if (_webHostEnvironment.IsDevelopment())
            {
                problemDetails.Detail += $": {ex.StackTrace}";
            }

            context.Response.StatusCode = problemDetails.Status.Value;
            context.Response.ContentType = "application/problem+json";

            using var writer = new Utf8JsonWriter(context.Response.Body);
            JsonSerializer.Serialize(writer, problemDetails);
            await writer.FlushAsync();
        }
    }
}
