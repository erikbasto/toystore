using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToyStore.Model;

namespace ToyStore.DataAccess
{
    /// <summary>
    /// DbContext used by EFCore
    /// </summary>
    public class ToyStoreDbContext : DbContext
    {
        private readonly IConfiguration configuration;
        public virtual DbSet<Product> Products { get; set; }

        public ToyStoreDbContext() { }

        public ToyStoreDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("ToyStoreDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Seed();
        }
    }
}
