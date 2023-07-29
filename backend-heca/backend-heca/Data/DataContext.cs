using backend_heca.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_heca.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=heca;Trusted_Connection=true;TrustServerCertificate=true");
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ticket>().HasKey(t => new
            {
                t.userId,
                t.trainId
            });
        }*/

        public DbSet<Ticket> Tikets { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
