using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Bookstore.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure services here
            services.AddLogging(logging =>
            {
                logging.AddConfiguration(Configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();
            });
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env, ILoggerFactory loggerFactory)
        {
            // Logging is now configured in ConfigureServices

            ConfigurationSetup.ConfigureConfiguration();

            // DependencyInjection is now handled in ConfigureServices method

            // Update authentication configuration for ASP.NET Core
            AuthenticationConfig.ConfigureAuthentication(app);

            // Add other middleware and routing configuration here
        }
    }
}