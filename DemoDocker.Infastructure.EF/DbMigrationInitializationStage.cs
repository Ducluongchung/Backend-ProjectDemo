using DemoDocker.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoDocker.Infastructure.EF
{
    public class DbMigrationInitializationStage : IInitializationStage
    {
        private readonly DemoDbContext _dbContext;
        public int Order => 1;
        public DbMigrationInitializationStage(DemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ExecuteAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}
