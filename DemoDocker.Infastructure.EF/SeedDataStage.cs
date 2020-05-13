using DemoDocker.Domain.Data.Product;
using DemoDocker.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDocker.Infastructure.EF
{
    public class SeedDataStage : IInitializationStage
    {
        private readonly DemoDbContext _dbContext;

        public SeedDataStage(DemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Order => 2;

        public async Task ExecuteAsync()
        {
            if (_dbContext.Products.Count() == 0)
            {
                var product = new List<Product>()
                {
                     new Product() { Name = "San pham 1", SeoAlias = "san-pham-1", Price = 200000, Description = "san pham 1", DateCreated = DateTime.Now },
                    new Product() { Name = "San pham 2", SeoAlias = "san-pham-2", Price = 400000, Description = "san pham 2", DateCreated = DateTime.Now }
            };
                _dbContext.Products.AddRange(product);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
