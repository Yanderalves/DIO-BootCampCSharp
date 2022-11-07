using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;

namespace AplicacaoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
    public class BloggingContextFactory : IDesignTimeDbContextFactory<AgendaContext>
    {
        public AgendaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AgendaContext>();
            optionsBuilder.UseSqlServer(connectionString:"server=localhost\\sqlexpress;Initial Catalog=Agenda; Integrated Security=true");

            return new AgendaContext(optionsBuilder.Options);
        }
    }
}
