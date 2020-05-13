using DemoDoker.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDoker.Data
{
    public class DemoDbContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        public DemoDbContext() : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasKey(x=>x.Id);

        }
    }
}
