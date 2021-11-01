using Autofac;
using Core.Configuration;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.Web.Mvc;
using MedioClinic.Configuration;
using MedioClinic.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using XperienceAdapter.Localization;

namespace MedioClinic
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }

        public AutoFacConfig AutoFacConfig => new AutoFacConfig();
        public IConfigurationSection? Options { get; }
        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Options = configuration.GetSection(nameof(XperienceOptions));
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Enable desired Kentico Xperience features
            var kenticoServiceCollection = services.AddKentico(features =>
            {
                // features.UsePageBuilder();
                // features.UseActivityTracking();
                // features.UseABTesting();
                // features.UseWebAnalytics();
                // features.UseEmailTracking();
                // features.UseCampaignLogger();
                // features.UseScheduler();
                // features.UsePageRouting();
                features.UsePageRouting(new PageRoutingOptions { CultureCodeRouteValuesKey = "culture" });
            });

            if (Environment.IsDevelopment())
            {
                // By default, Xperience sends cookies using SameSite=Lax. If the administration and live site applications
                // are hosted on separate domains, this ensures cookies are set with SameSite=None and Secure. The configuration
                // only applies when communicating with the Xperience administration via preview links. Both applications also need 
                // to use a secure connection (HTTPS) to ensure cookies are not rejected by the client.
                kenticoServiceCollection.SetAdminCookiesSameSiteNone();

                // By default, Xperience requires a secure connection (HTTPS) if administration and live site applications
                // are hosted on separate domains. This configuration simplifies the initial setup of the development
                // or evaluation environment without a the need for secure connection. The system ignores authentication
                // cookies and this information is taken from the URL.
                kenticoServiceCollection.DisableVirtualContextSecurityForLocalhost();
            }

            // services.AddAuthentication();
            // services.AddAuthorization();
            services.Configure<XperienceOptions>(Options);
            services.AddAntiforgery();
            services.AddLocalization();
            services.AddControllersWithViews()
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = typeof(SharedResource).GetTypeInfo().Assembly.GetName().Name;

                        return factory.Create("SharedResource", assemblyName);
                    };
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/html";

                        await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
                        await context.Response.WriteAsync("An error happened.<br><br>\r\n");

                        var exceptionHandlerPathFeature =
                            context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();

                        if (exceptionHandlerPathFeature?.Error is System.IO.FileNotFoundException)
                        {
                            await context.Response.WriteAsync("A file error happened.<br><br>\r\n");
                        }

                        await context.Response.WriteAsync("<a href=\"/\">Home</a><br>\r\n");
                        await context.Response.WriteAsync("</body></html>\r\n");
                        await context.Response.WriteAsync(new string(' ', 512)); // IE padding
                    });
                });
            }

            app.UseLocalizedStatusCodePagesWithReExecute("/{0}/error/{1}/");

            app.UseStaticFiles();

            app.UseKentico();
            app.UseRequestCulture();

            app.UseCookiePolicy();

            app.UseCors();

            // app.UseAuthentication();
            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.Kentico().MapRoutes();


            });
        }


        private void RegisterInitializationHandler(ContainerBuilder builder) =>
    CMS.Base.ApplicationEvents.Initialized.Execute += (sender, eventArgs) => AutoFacConfig.ConfigureContainer(builder);

        public void ConfigureContainer(ContainerBuilder builder)
        {
            try
            {
                AutoFacConfig.ConfigureContainer(builder);
            }
            catch
            {
                RegisterInitializationHandler(builder);
            }
        }
    }
}
