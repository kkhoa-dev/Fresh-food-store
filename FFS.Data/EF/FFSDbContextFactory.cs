using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FFS.Data.EF
{
    public class FFSDbContextFactory : IDesignTimeDbContextFactory<FFSDbContext>
    {
            public FFSDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("FreshFoodStoreDb");

                var optionsBuilder = new DbContextOptionsBuilder<FFSDbContext>();
                optionsBuilder.UseSqlServer(connectionString);

                return new FFSDbContext(optionsBuilder.Options);
            }
        }
    }
