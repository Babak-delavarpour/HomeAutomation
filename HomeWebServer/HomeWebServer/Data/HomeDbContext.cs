using HomeWebServer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HomeWebServer
{
    public class HomeDbContext:DbContext
    {
        public HomeDbContext(DbContextOptions<HomeDbContext> option) :base(option)
        {
            
        }
        public DbSet<Device> Devices { get; set; }

    }
}
