using System.Reflection.Metadata.Ecma335;
using DishesAPI.DbContexts;
using DishesAPI.Models;
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

app.MapGet("/dishes", async (DishesDbContext dishesDbContext, 
    IMapper mapper) => 
{
    return mapper.Map<IEnumerable<DishDto>>(await dishesDbContext.Dishes.ToListAsync());
});

app.MapGet("/dishes/{dishId:guid}", async (DishesDbContext dishesDbContext, 
    IMapper mapper, Guid dishId) =>
{
    return mapper.Map<DishDto>(await dishesDbContext.Dishes
        .FirstOrDefaultAsync(d => d.Id == dishId));
});

app.MapGet("/dishes/{dishName}", async (DishesDbContext dishesDbContext, 
    IMapper mapper, string dishName) =>
{
    return mapper.Map<DishDto>(await dishesDbContext.Dishes
        .FirstOrDefaultAsync(d => d.Name == dishName));
});

app.MapGet("/dishes/{dishId}/ingredients", async (DishesDbContext dishesDbContext, 
    IMapper mapper, Guid dishId) =>
{
    return mapper.Map<IEnumerable<IngredientDto>>((await dishesDbContext.Dishes
        .Include(d => d.Ingredients)
        .FirstOrDefaultAsync(d => d.Id == dishId))?.Ingredients);
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
