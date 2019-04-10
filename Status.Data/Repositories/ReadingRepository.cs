using Microsoft.Extensions.Configuration;
using Status.Data.Contexts;
using Status.Data.Models;
using Status.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Status.Data.Repositories
{
    public class ReadingRepository : IReadingRepository
    {
        private readonly IConfigurationRoot config;
        private readonly StatusDbContext context;

        public ReadingRepository(IConfigurationRoot config)
        {
            this.config = config;
            context = new StatusDbContext(options => options.Use);
        }

        public void CreateReading(Reading reading)
        {
            
        }

        public Reading GetLatestReading()
        {
            throw new NotImplementedException();
        }

        public Reading GetReading(int id)
        {
            throw new NotImplementedException();
        }
    }
}
