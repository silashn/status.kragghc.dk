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
            reading.Created = DateTime.Now;
            db.Readings.Add(reading);
            db.SaveChanges();
        }

        public Reading GetLatestReading()
        {
            return db.Readings.Include(r => r.Disks).OrderByDescending(r => r.Created).FirstOrDefault();
        }

        public Reading GetReading(int id)
        {
            return db.Readings.Include(r => r.Disks).FirstOrDefault(r => r.ID.Equals(id));
        }

        public List<Reading> GetReadings()
        {
            return db.Readings.Include(r => r.Disks).OrderByDescending(r => r.Created).ToList();
        }

        public List<Reading> GetReadings(DateTime from)
        {
            return db.Readings.Include(r => r.Disks).Where(r => r.Created >= from).OrderBy(r => r.Created).ToList();
        }

        public List<Reading> GetReadings(DateTime from, DateTime to)
        {
            return db.Readings.Include(r => r.Disks).Where(r => r.Created >= from && r.Created <= to).OrderBy(r => r.Created).ToList();
        }

        public List<Reading> GetReadings(int recent)
        {
            return db.Readings.Include(r => r.Disks).OrderBy(r => r.Created).Take(recent).ToList();
        }
    }
}
