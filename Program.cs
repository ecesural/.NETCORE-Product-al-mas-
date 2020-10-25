using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Management.Batch.Fluent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RelatedDigital.Product.Data.Concrete.Entities;
using RelatedDigital.Product.Data.Interfaces;

namespace RelatedDigital.Product.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var container= AutofacDependecyBuilder.DependencyBuilder();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IRepository<Products>>();
               
            }
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
