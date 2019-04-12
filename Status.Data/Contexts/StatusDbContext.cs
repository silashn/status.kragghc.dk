using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Status.Data.Models;

namespace Status.Data.Contexts
{
    public class StatusDbContext : DbContext
    {
        public DbSet<Reading> Readings { get; set; }
        public DbSet<Disk> Disks { get; set; }
        public StatusDbContext(DbContextOptions<StatusDbContext> options) : base(options)
        {

        }
    }
}
