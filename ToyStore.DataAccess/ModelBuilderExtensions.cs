using Microsoft.EntityFrameworkCore;
using ToyStore.Model;

namespace ToyStore.DataAccess
{
    /// <summary>
    /// Extension to feed the db
    /// </summary>
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Zelda BOTW",
                    AgeRestriction = 13,
                    Company = "Nintendo",
                    Description = "The Legend of Zelda Breath of the Wild",
                    Price = 1300
                },
                new Product
                {
                    Id = 2,
                    Name = "Smash",
                    AgeRestriction = 13,
                    Company = "Nintendo",
                    Description = "Super Smash Bros Ultimate",
                    Price = 1500
                }
            );
        }
    }
}