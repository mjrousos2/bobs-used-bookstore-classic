using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Bookstore.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure services here
            services.AddLogging(logging =>
            {
                logging.AddConfiguration(Configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();
            });

            // Add any additional configuration setup here
            services.AddSingleton(Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger<Startup>();
            logger.LogInformation("Application Starting");

            // DependencyInjection is now handled in ConfigureServices method

            // Update authentication configuration for ASP.NET Core
            AuthenticationConfig.ConfigureAuthentication(app);

            // Add other middleware and routing configuration here
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    public static class AuthenticationConfig
    {
        public static void ConfigureAuthentication(IApplicationBuilder app)
        {
            // Implement authentication configuration here
            // For example:
            // app.UseAuthentication();
            // app.UseAuthorization();
        }
    }
}