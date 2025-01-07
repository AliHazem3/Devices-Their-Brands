using Device_and_Its_Brands.Models;
using Microsoft.EntityFrameworkCore;

namespace Device_and_Its_Brands.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categorx { get; set; }  // Make sure this isn't duplicated

        public DbSet<Product> Productx { get; set; }
    }
}