using Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Unleash.Demo.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IFeatureToggler, UnleashClient>(serviceProvider =>
                new UnleashClient(config["Unleash:Url"], config["Unleash:ApiKey"]));
        }
    }
}
