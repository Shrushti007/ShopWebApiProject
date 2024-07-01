using Microsoft.EntityFrameworkCore;
using ShopWebApiProject.Models;

namespace ShopWebApiProject.Data
{
    public class ShopeDbContext:DbContext
    {
        public ShopeDbContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
