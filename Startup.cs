using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.ServiceModel.Channels;
using System.ServiceModel;
using Game.Models;
using SoapCore;
using Game.Data;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Game
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
            services.AddRazorPages();
           // services.TryAddSingleton<ISampleService, SampleService>();


            services.AddDbContext<GameContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("GameContext")));


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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
           app.UseMiddleware<Middleware>();
            /*app.Use(async (context, next) =>
            {
                var sw = new cc();
                sw.Start();
                await next.Invoke();
                sw.Stop();
                await context.Response.WriteAsync(String.Format("<!-- {0} ms -->", sw.ElapsedMilliseconds));
            });*/

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
