using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using WebStore_2020.Infrastructure;
using WebStore_2020.Infrastructure.Interfaces;
using WebStore_2020.Infrastructure.Services;

namespace WebStore_2020
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => 
            {
                //options.Filters.Add(typeof(SimpleActionFilter));
                //options.Filters.Add(new SimpleActionFilter());
            });

            services.AddSingleton<IEmployeeService, InMemoryEmployeeService>();
            services.AddSingleton<ICigaretteService, InMemoryCiggaretsService>();
            services.AddSingleton<IProductService, InMemoryProductService>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.Map("/index", CustomIndexHandler);

            app.UseRouting();

            string helloMsg = configuration["CustomHelloWorld"];

            //app.UseMvcWithDefaultRoute(); альтернатива коду ниже

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });

        }

        private void CustomIndexHandler(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello");
            });
        }
    }
}
