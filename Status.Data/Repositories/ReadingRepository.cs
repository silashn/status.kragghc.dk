using Microsoft.EntityFrameworkCore;
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
        private readonly StatusDbContext db;

        public ReadingRepository(DbContextOptions<StatusDbContext> options)
        {
            db = new StatusDbContext(options);
        }

        public void CreateReading(Reading reading)
        {
            db.Readings.Add(reading);
            db.SaveChanges();
        }

        public Reading GetLatestReading()
        {
            return db.Readings.OrderByDescending(r => r.Created).FirstOrDefault();
        }

        public Reading GetReading(int id)
        {
            return db.Readings.FirstOrDefault(r => r.ID.Equals(id));
        }
    }
}
