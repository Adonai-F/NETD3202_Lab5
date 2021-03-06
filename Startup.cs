using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// New imported models
using Lab5.Models;
using Microsoft.AspNetCore.Mvc;
// Install these two from nuget manager
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
// Install Microsoft.EntityFrameworkCore.Tools on nuget

namespace Lab5
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // Disable endpoint routing
            services.AddMvc(options => options.EnableEndpointRouting = false);

            // Adding a connection
            string connection = @"Server=(localdb)\mssqllocaldb;Database=Lab5;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<InventoryContex>(options => options.UseSqlServer(connection));
            /*To create database: Tools - NuGet Package Manager- PAckage Manager Console. 
             * Type in console: Add-Migration InitialCreate. 
             * Creates Migration folder. Go back to console
             * Run Update-Database
             * View - Sql Server Object Explorer
             */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
