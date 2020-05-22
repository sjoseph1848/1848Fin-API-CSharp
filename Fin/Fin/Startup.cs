using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fin.Biz;
using Fin.Data;
using Fin.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using Microsoft.CodeAnalysis.Options;

namespace Fin
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200",
                                            "https://1848fin.com",
                                            "https://1848finapi.azurewebsites.net");
                    });
            });
            services.AddHttpClient(name: "NewsService",
                configureClient: options =>
                {
                    options.BaseAddress = new Uri("https://newsapi.org/v2/");
                    options.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue(
                            "application/json", 1.0));
                });
            services.AddScoped<IndexStock>();
            services.AddControllers();
            services.AddDbContext<StoreContext>(x => x.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
