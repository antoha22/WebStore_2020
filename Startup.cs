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
            services.AddMvc();
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
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Cigarette}/{action=ReturnList}/{id?}"
                //    );
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync(helloMsg);
                //});
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
