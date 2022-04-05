using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySQLApp.Models;

namespace MySQLApp
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

            //Database
            services.AddDbContext<BowlersDBContext>(options =>
           {
               //options.UseMySql(Configuration.GetConnectionString("BowlingLeagueDbConnection"));
               options.UseMySql(Configuration["ConnectionStrings:BowlersDBConntection"]);

           });

            services.AddScoped<IBowlersRepository, EFBolwersRepository>();

            services.AddRazorPages();

            //Use Blazor
            services.AddServerSideBlazor();

            services.AddDistributedMemoryCache();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "teams",
                pattern: "{teams}",
                defaults: new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute("typepage",
            //        "{teamName}/Page{pageNum}",
            //    new { Controller = "Home", Action = "Index" });

            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");

            //    endpoints.MapRazorPages();
            //    endpoints.MapBlazorHub();
            //    endpoints.MapFallbackToPage("/edit/{*catchall}", "/Index");
            //});
        }
    }
}
