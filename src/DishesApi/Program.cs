using System.Reflection.Metadata.Ecma335;
using DishesAPI.DbContexts;
using DishesAPI.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using DishesAPI.Entities;

var builder = WebApplication.CreateBuilder(args);

//add services to the container here
builder.Services.AddDbContext<DishesDbContext>(o => o.UseSqlite(
    builder.Configuration["ConnectionStrings:DishesDBConnectionString"]));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

//configure the request pipeline here
app.UseHttpsRedirection();

app.MapGet("/dishes", async Task<Ok<IEnumerable<DishDto>>> 
    (DishesDbContext dishesDbContext, ClaimsPrincipal claimsPrincipal,
    IMapper mapper, [FromQuery] string? name) => 
{
    Console.WriteLine($"User authenticated? {claimsPrincipal.Identity?.IsAuthenticated}");

    return TypedResults.Ok(mapper.Map<IEnumerable<DishDto>>(await dishesDbContext.Dishes
    .Where(d => name == null || d.Name.Contains(name))    
    .ToListAsync()));
});

app.MapGet("/dishes/{dishId:guid}", async Task<Results<NotFound, Ok<DishDto>>> 
    (DishesDbContext dishesDbContext, IMapper mapper, Guid dishId) =>
{
    var dishEntity = await dishesDbContext.Dishes
        .FirstOrDefaultAsync(d => d.Id == dishId);

    if(null == dishEntity)
        return TypedResults.NotFound();
    else
        return TypedResults.Ok(mapper.Map<DishDto>(dishEntity));

}).WithName("GetDish");

app.MapGet("/dishes/{dishName}", async Task<Ok<DishDto>> 
    (DishesDbContext dishesDbContext, IMapper mapper, string dishName) =>
{
    return TypedResults.Ok(mapper.Map<DishDto>(await dishesDbContext.Dishes
        .FirstOrDefaultAsync(d => d.Name == dishName)));
});

app.MapGet("/dishes/{dishId}/ingredients", async Task<Results<NotFound,Ok<IEnumerable<IngredientDto>>>>
    (DishesDbContext dishesDbContext, IMapper mapper, Guid dishId) =>
{
    var dishEntity = await dishesDbContext.Dishes
        .FirstOrDefaultAsync(d => d.Id == dishId);
    if(null == dishEntity)
        return TypedResults.NotFound();

    return TypedResults.Ok(mapper.Map<IEnumerable<IngredientDto>>((await
        dishesDbContext.Dishes
            .Include(d => d.Ingredients)
            .FirstOrDefaultAsync(d => d.Id == dishId))?.Ingredients));
});

app.MapPost("/dishes", async Task<CreatedAtRoute<DishDto>> (DishesDbContext dishesDbContext, 
    IMapper mapper, DishForCreationDto dish/*, 
    LinkGenerator linkGenerator, HttpContext httpContext*/    
    ) =>
{
        var dishEntity = mapper.Map<Dish>(dish);
        dishesDbContext.Add(dishEntity);
        await dishesDbContext.SaveChangesAsync();

        var dishToReturn = mapper.Map<DishDto>(dishEntity);
        //var linkToDish = linkGenerator.GetUriByName(httpContext, "GetDish", new {dishId = dishToReturn.Id});
        //return TypedResults.Created(linkToDish, dishToReturn);

        return TypedResults.CreatedAtRoute(dishToReturn, "GetDish", new {dishId = dishToReturn.Id});

});
   
app.MapPut("/dishes/{dishId:guid}", async Task<Results<NotFound, NoContent>> (DishesDbContext dishesDbContext, 
    IMapper mapper, Guid dishId, DishForUpdateDto dish) =>
{
    var dishEntity = await dishesDbContext.Dishes.FirstOrDefaultAsync(d => d.Id == dishId);
    if(null == dishEntity)
        return TypedResults.NotFound();

    mapper.Map(dish, dishEntity);

    await dishesDbContext.SaveChangesAsync();
    return TypedResults.NoContent();

});

app.MapDelete("/dishes/{dishId:guid}", async Task<Results<NotFound, NoContent>> (DishesDbContext dishesDbContext, 
    Guid dishId) =>
{
    var dishEntity = await dishesDbContext.Dishes.FirstOrDefaultAsync(d => d.Id == dishId);
    if(null == dishEntity)
        return TypedResults.NotFound();

    dishesDbContext.Dishes.Remove(dishEntity);
    await dishesDbContext.SaveChangesAsync();
    return TypedResults.NoContent();

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
