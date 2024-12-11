using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bookstore.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure services here
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            LoggingSetup.ConfigureLogging();

            ConfigurationSetup.ConfigureConfiguration();

            // DependencyInjection is now handled in ConfigureServices method

            // Update authentication configuration for ASP.NET Core
            AuthenticationConfig.ConfigureAuthentication(app);

            // Add other middleware and routing configuration here
        }
    }
}