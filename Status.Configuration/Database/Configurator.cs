using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Status.Data.Contexts;
using Status.Data.Repositories;
using Status.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Status.Configuration.Database
{
    public class Configurator
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IReadingRepository, ReadingRepository>();

            //AppSettings
            services.AddDbContext<StatusDbContext>(options => options.UseSqlServer(config.GetConnectionString("azure.aspiri.dk"), o => o.MigrationsAssembly("Status.Web")));
        }
    }
}
