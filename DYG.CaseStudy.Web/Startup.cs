using DYG.CaseStudy.Core.Abstract;
using DYG.CaseStudy.Core.Concrete;
using DYG.CaseStudy.Web.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace DYG.CaseStudy.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddTransient<ILogger, Logger<string>>();
            services.AddTransient<ICacheManager, RootCacheManager>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddOptions();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {



            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile(Path.Combine(path, "Log", "Log.txt"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else 
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseRequestResponseLogging();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "news",
                //    template: "{slug}/{title},{id}",
                //    defaults: new { controller = "Home", action = "GetNewsDetail" });

                routes.MapRoute(
                 name: "news",
                 template: "{slug}/{title},{id}",
                 defaults: new { controller = "Home", action = "GetNewsDetail" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
