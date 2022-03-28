using Poc.Middleware.Api.Service;
using Poc.Middleware.Api.Service.Interface;
using System.Diagnostics.CodeAnalysis;

namespace Poc.Middleware.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IValueService, ValueService>();
            services.AddScoped<ICredentialService, CredentialService>();
        }
    }
}
