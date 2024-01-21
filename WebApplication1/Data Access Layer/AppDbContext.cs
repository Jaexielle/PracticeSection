using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data_Access_Layer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}
