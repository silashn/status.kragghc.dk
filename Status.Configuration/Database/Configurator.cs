using Microsoft.Extensions.DependencyInjection;
using Status.Data.Contexts;
using Status.Data.Repositories;
using Status.Data.Repositories.Interfaces;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Status.Configuration.Database
{
    public class Configurator
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration config)
        {

            services.AddScoped<IReadingRepository, ReadingRepository>();

            //Appsettings
            services.AddDbContext<StatusDbContext>(options => options.UseSqlServer(config.GetConnectionString("status.kragghc.dk"), x => x.MigrationsAssembly("Status.Logger")));
        }
    }
}
