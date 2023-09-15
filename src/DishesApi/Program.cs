using System.Reflection.Metadata.Ecma335;
using DishesAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

//add services to the container here
builder.Services.AddDbContext<DishesDbContext>(o => o.UseSqlite(
    builder.Configuration["ConnectionStrings:DishesDBConnectionString"]));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

//configure the request pipeline here
app.UseHttpsRedirection();

app.MapGet("/dishes", async (DishesDbContext dishesDbContext) => 
{
    return await dishesDbContext.Dishes.ToListAsync();
});

app.MapGet("/dishes/{dishId:guid}", async (DishesDbContext dishesDbContext, 
    Guid dishId) =>
{
    return await dishesDbContext.Dishes
        .FirstOrDefaultAsync(d => d.Id == dishId);
});

app.MapGet("/dishes/{dishName}", async (DishesDbContext dishesDbContext, 
    string dishName) =>
{
    return await dishesDbContext.Dishes
        .FirstOrDefaultAsync(d => d.Name == dishName);
});

app.MapGet("/dishes/{dishId}/ingredients", async (DishesDbContext dishesDbContext, 
    Guid dishId) =>
{
    var result = await (dishesDbContext.Dishes
        .Include(d => d.Ingredients)
        .FirstOrDefaultAsync(d => d.Id == dishId));

    return result?.Ingredients;

});
   

//recreate & migrate the database on each run, for demo purposes
#pragma warning disable CS8602
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<DishesDbContext>();
    context.Database.EnsureDeleted();
    context.Database.Migrate();
}
#pragma warning restore CS8602

app.Run();
