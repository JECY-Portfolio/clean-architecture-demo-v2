using clean_architecture_demo_v2.Domain.Repository;
using clean_architecture_demo_v2.Infrastructure.Data;
using clean_architecture_demo_v2.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace clean_architecture_demo_v2.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BlogDbContext") ??
                    throw new InvalidOperationException("Connection string 'BlogDbContext not found'"))
            );

            services.AddTransient<IBlogRepository, BlogRepository>();
            return services;
        }
    }
}
