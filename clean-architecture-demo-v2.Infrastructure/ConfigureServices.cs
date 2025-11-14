using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace clean_architecture_demo_v2.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
