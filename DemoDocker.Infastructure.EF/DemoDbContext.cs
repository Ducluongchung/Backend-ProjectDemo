using DemoDocker.Domain.Data.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDocker.Infastructure.EF
{
    public class DemoDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {
        }
        public DemoDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>()
                    .Property(p => p.Id)
                        .ValueGeneratedOnAdd();
            //modelBuilder.Entity<Product>().HasData(
            //        new { Id = 1, Name = "San pham 1", SeoAlias = "san-pham-1", Price = 200000, Description = "san pham 1", DateCreated = DateTime.Now },
            //        new { Id = 2, Name = "San pham 2", SeoAlias = "san-pham-2", Price = 400000, Description = "san pham 2", DateCreated = DateTime.Now });
        }
    }
}
