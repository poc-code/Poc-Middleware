using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Moq;
using Poc.Middleware.Api.Middleware;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Poc.Middleware.Tests
{
    public class ErrorHandlerMiddlewareTest
    {
        private readonly Mock<IWebHostEnvironment> _webHostEnvironmentMock;

        public ErrorHandlerMiddlewareTest()
        {
            _webHostEnvironmentMock = new Mock<IWebHostEnvironment>();
        }

        [Fact]
        public async Task InvokeErrorHandler_ExceptionTest()
        {

            _webHostEnvironmentMock.Setup(x => x.EnvironmentName)
                .Returns("Development");

            var httpContext = new DefaultHttpContext().Request.HttpContext;
            var exceptionHandlerFeature = new ExceptionHandlerFeature()
            {
                Error = new Exception("Mock error exception")
            };

            httpContext.Features.Set<IExceptionHandlerFeature>(exceptionHandlerFeature);

            var errorHandlerMiddleware = new ErrorHandlerMiddleware(_webHostEnvironmentMock.Object);
            await errorHandlerMiddleware.Invoke(httpContext);

            Assert.NotNull(errorHandlerMiddleware);
        }

        [Fact]
        public async Task InvokeErrorHandler_NotExceptionTest()
        {
            _webHostEnvironmentMock.Setup(x => x.EnvironmentName)
                .Returns("Development");

            var httpContext = new DefaultHttpContext().Request.HttpContext;

            var errorHandlerMiddleware = new ErrorHandlerMiddleware(_webHostEnvironmentMock.Object);
            await errorHandlerMiddleware.Invoke(httpContext);

            Assert.NotNull(errorHandlerMiddleware);
        }
    }
}
