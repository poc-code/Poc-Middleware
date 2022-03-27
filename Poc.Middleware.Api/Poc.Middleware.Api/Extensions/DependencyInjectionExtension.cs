using Poc.Middleware.Api.Service;
using Poc.Middleware.Api.Service.Interface;

namespace Poc.Middleware.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IValueService, ValueService>();
        }
    }
}
