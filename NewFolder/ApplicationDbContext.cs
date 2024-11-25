using Microsoft.EntityFrameworkCore;
using CMCS.Models; // Ensure this matches the namespace of your models

namespace CMCS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for each entity you want to track in the database
        public DbSet<Claim> Claims { get; set; }
        public DbSet<User> Users { get; set; }
        // Add other DbSets here for other entities if needed
       
    }
}

