using Microsoft.EntityFrameworkCore;
using WebAPITest.Models;

namespace WebAPITest.EBbContext
{
    public class ZealandIdDbContext : DbContext
    {
        public ZealandIdDbContext(DbContextOptions<ZealandIdDbContext> options) : base(options)
        {
        }

        // DbSet properties and other configurations...     
        public DbSet<Sensor> Sensorer { get; set; }
        public DbSet<Lokale> lokaler { get; set; }
    }
}
