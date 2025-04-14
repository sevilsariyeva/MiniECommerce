using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Entities;

namespace WebApplication1.Data
{
    public class MarketDbContext:DbContext
    {

        public MarketDbContext(DbContextOptions<MarketDbContext> options)
         : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Order>().ToTable("Orders");

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "T-Shirt", Price = 59, Discount = 15 },
                new Product { Id = 2, Name = "Trousers", Price = 119, Discount = 25 },
                new Product { Id = 3, Name = "Shirt", Price = 89, Discount = 5 },
                new Product { Id = 4, Name = "Blouse", Price = 69, Discount = 35 },
                new Product { Id = 5, Name = "Short", Price = 79, Discount = 45 }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Jane", Surname = "Johnson" },
                new Customer { Id = 2, Name = "Mike", Surname = "Black" },
                new Customer { Id = 3, Name = "Lisa", Surname = "Kudrow" },
                new Customer { Id = 4, Name = "Monica", Surname = "Geller" },
                new Customer { Id = 5, Name = "Daniel", Surname = "Ronald" }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, ProductId = 1, CustomerId = 1, OrderDate = new DateTime(2023, 01, 01) },
                new Order { Id = 2, ProductId = 2, CustomerId = 2, OrderDate = new DateTime(2023, 02, 01) },
                new Order { Id = 3, ProductId = 3, CustomerId = 3, OrderDate = new DateTime(2023, 03, 01) },
                new Order { Id = 4, ProductId = 4, CustomerId = 4, OrderDate = new DateTime(2023, 04, 01) },
                new Order { Id = 5, ProductId = 5, CustomerId = 5, OrderDate = new DateTime(2023, 05, 01) }
            );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }

    }
}
