using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Util;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RelatedDigital.Product.Business.Interfaces;
using RelatedDigital.Product.Data.Concrete.Contexts;
using RelatedDigital.Product.Data.Concrete.Entities;
using RelatedDigital.Product.Data.Concrete.Repository;
using RelatedDigital.Product.Data.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace RelatedDigital.Product.API
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
            //var connection = @"Data Source=localhost\\SQLEXPRESS; Trusted_Connection=True;Initial Catalog=RelatedDigitalDB;MultipleActiveResultSets=true";
            

            services.AddDbContext<RelatedDigitalContext>();
            services.AddScoped<IRepository<Products>, ProductRepository>();
            services.AddScoped<IRepository<Colors>, ColorRepository>();
            services.AddScoped<IRepository<Colors>, ColorRepository>();

            services.AddSwaggerDocument();
           services.AddControllers();
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();



            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
