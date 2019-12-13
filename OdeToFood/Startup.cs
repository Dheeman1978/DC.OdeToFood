using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OdeToFood.Data;

namespace OdeToFood
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
            services.AddDbContextPool<OdeToFoodDbContext>(options => {

                options.UseSqlServer(Configuration.GetConnectionString("OdeToFoodDb"));                
            });
            // services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
            services.AddScoped<IRestaurantData, SqlRestaurantData>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Configures/Installs all Middlewares
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //cares only about outgoing response, does not care about incoming request. 
                //call next middleware, and see if any middleware throws any exception and handle that exception, catches unhandled exception and shows stacktrace.
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.Use(async (ctx,next) =>
            {
                if (ctx.Request.Path.StartsWithSegments("/hellodc"))
                {
                    await ctx.Response.WriteAsync("Hello World!");
                }
                else
                {
                    await next();
                }

            });

           

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseNodeModules(env); //installs middleware in the processing pipleines for ASP.NET Core
            app.UseCookiePolicy();

            app.UseMvc();
        }

      

        private RequestDelegate SayHelloMiddleware(RequestDelegate next)
        {
            return async ctx =>
            {
                if (ctx.Request.Path.StartsWithSegments("/hello"))
                {
                    await ctx.Response.WriteAsync("Hello World!");
                }
                else
                {
                    await next(ctx);
                }
                
            };
        }
    }
}
