using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace MappingDemo
{
    public class SalesContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public int TotalSpentByCustomer(int customerId)
     => throw new NotSupportedException();


        public IQueryable<CustWithTotalClass> NameAndTotalSpentByCustomer()
          => FromExpression(() => NameAndTotalSpentByCustomer());

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MappingDemo");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(typeof(SalesContext)
                .GetMethod(nameof(TotalSpentByCustomer),
                           new[] { typeof(int) }))
                .HasName("TotalSpentByCustomer");

            modelBuilder.HasDbFunction(typeof(SalesContext)
             .GetMethod(nameof(NameAndTotalSpentByCustomer)))
             .HasName("CustomerNameAndTotalSpent");

            modelBuilder.Entity<CustWithTotalClass>().HasNoKey();

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "Julie" },
                new Customer { CustomerId = 2, Name = "Joanne" });

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, Date = DateTime.Today.AddDays(-1), CustomerId = 1 },
                new Order { OrderId = 2, Date = DateTime.Today, CustomerId = 1 },
                new Order { OrderId = 3, Date = DateTime.Today, CustomerId = 2 }
            );
            modelBuilder.Entity<Product>().HasData(
                 new Product { ProductId = 1, Description = "Red Bicycle", UnitPrice = 100 },
                 new Product { ProductId = 2, Description = "Blue gloves", UnitPrice = 10 },
                 new Product { ProductId = 3, Description = "Green jersey", UnitPrice = 20 }
                 );
            modelBuilder.Entity<LineItem>().HasData(
                new LineItem { LineItemId = 1, OrderId = 1, ProductId = 1, Quantity = 1 },
                new LineItem { LineItemId = 2, OrderId = 1, ProductId = 2, Quantity = 1 },
                new LineItem { LineItemId = 3, OrderId = 2, ProductId = 3, Quantity = 1 },
                new LineItem { LineItemId = 4, OrderId = 3, ProductId = 1, Quantity = 1 }
                );
        }
    }
}
