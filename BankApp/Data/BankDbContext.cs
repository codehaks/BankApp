using Microsoft.EntityFrameworkCore;

namespace BankApp.Data
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<User>().HasQueryFilter(u=>u.Country=="CA");

            base.OnModelCreating(builder);
        }
    }
}