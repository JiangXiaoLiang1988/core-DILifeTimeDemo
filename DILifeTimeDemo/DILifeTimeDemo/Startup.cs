using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DILifeTimeDemo.Domain;
using DILifeTimeDemo.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DILifeTimeDemo
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
            services.AddMvc();
            // 注入瞬时生命周期
            services.AddTransient<IGuidTransientService, GuidTransientService>();
            // 注入Scoped作用域生命周期
            services.AddScoped<IGuidScopedService, GuidScopedService>();
            // 注入单例声明周期
            services.AddSingleton<IGuidSingletonService, GuidSingletonService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
