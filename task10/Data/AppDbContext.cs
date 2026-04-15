using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace ProductsAPI.Data{
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 75000, Stock = 10 },
                new Product { Id = 2, Name = "Mouse", Price = 999, Stock = 50 },
                new Product { Id = 3, Name = "Keyboard", Price = 1999, Stock = 30 }
            );
        }
    }
}