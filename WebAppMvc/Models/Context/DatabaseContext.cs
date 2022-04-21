using Microsoft.EntityFrameworkCore;
using WebAppMvc.Models.Entities;

namespace WebAppMvc.Models.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }    
    }
}
