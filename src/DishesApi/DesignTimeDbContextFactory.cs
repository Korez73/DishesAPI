using DishesAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DishesDbContext>
{
    public DishesDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var builder = new DbContextOptionsBuilder<DishesDbContext>();
        var connectionString = configuration.GetConnectionString("DishesDBConnectionString");
        builder.UseSqlite(connectionString);
        return new DishesDbContext(builder.Options);
    }
}