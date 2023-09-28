using System.Security.Claims;
using AutoMapper;
using DishesAPI.DbContexts;
using DishesAPI.Entities;
using DishesAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DishesAPI.EndpointHandlers;

public static class DishesHandlers
{
    public static async Task<Ok<IEnumerable<DishDto>>> GetDishesAsync
        (DishesDbContext dishesDbContext, ClaimsPrincipal claimsPrincipal,
        IMapper mapper, ILogger<DishDto> logger,
        string? name)
    {
        Console.WriteLine($"User authenticated? {claimsPrincipal.Identity?.IsAuthenticated}");

        logger.LogInformation("Getting the dishes....");

        return TypedResults.Ok(mapper.Map<IEnumerable<DishDto>>(await dishesDbContext.Dishes
            .Where(d => name == null || d.Name.Contains(name))    
            .ToListAsync()));
    }

    public static async Task<Results<NotFound, Ok<DishDto>>> GetDishesByGuidAsync
        (DishesDbContext dishesDbContext, IMapper mapper, Guid dishId)
    {
        var dishEntity = await dishesDbContext.Dishes
            .FirstOrDefaultAsync(d => d.Id == dishId);

        if(null == dishEntity)
            return TypedResults.NotFound();
        else
            return TypedResults.Ok(mapper.Map<DishDto>(dishEntity));

    }

    public static async Task<Ok<DishDto>> GetDishesByNameAsync
        (DishesDbContext dishesDbContext, IMapper mapper, string dishName)
    {
        return TypedResults.Ok(mapper.Map<DishDto>(await dishesDbContext.Dishes
            .FirstOrDefaultAsync(d => d.Name == dishName)));
    }

    public static async Task<Results<NotFound,Ok<IEnumerable<IngredientDto>>>> GetIngredientsWithDishGuidAsync
        (DishesDbContext dishesDbContext, IMapper mapper, Guid dishId)
    {
        var dishEntity = await dishesDbContext.Dishes
            .FirstOrDefaultAsync(d => d.Id == dishId);
        if(null == dishEntity)
            return TypedResults.NotFound();

        return TypedResults.Ok(mapper.Map<IEnumerable<IngredientDto>>((await
            dishesDbContext.Dishes
                .Include(d => d.Ingredients)
                .FirstOrDefaultAsync(d => d.Id == dishId))?.Ingredients));
    }

    public static async Task<CreatedAtRoute<DishDto>> CreateDishAsync
        (DishesDbContext dishesDbContext, IMapper mapper, DishForCreationDto dish/*, 
        LinkGenerator linkGenerator, HttpContext httpContext*/)
    {
        var dishEntity = mapper.Map<Dish>(dish);
        dishesDbContext.Add(dishEntity);
        await dishesDbContext.SaveChangesAsync();

        var dishToReturn = mapper.Map<DishDto>(dishEntity);
        //var linkToDish = linkGenerator.GetUriByName(httpContext, "GetDish", new {dishId = dishToReturn.Id});
        //return TypedResults.Created(linkToDish, dishToReturn);

        return TypedResults.CreatedAtRoute(dishToReturn, "GetDish", new {dishId = dishToReturn.Id});

    }

    public static async Task<Results<NotFound, NoContent>> UpdateDishAsync
        (DishesDbContext dishesDbContext, IMapper mapper, Guid dishId, DishForUpdateDto dish)
    {
        var dishEntity = await dishesDbContext.Dishes.FirstOrDefaultAsync(d => d.Id == dishId);
        if(null == dishEntity)
            return TypedResults.NotFound();

        mapper.Map(dish, dishEntity);

        await dishesDbContext.SaveChangesAsync();
        return TypedResults.NoContent();

    }

    public static async Task<Results<NotFound, NoContent>> DeleteDishAsync 
        (DishesDbContext dishesDbContext, Guid dishId)
    {
        var dishEntity = await dishesDbContext.Dishes.FirstOrDefaultAsync(d => d.Id == dishId);
        if(null == dishEntity)
            return TypedResults.NotFound();

        dishesDbContext.Dishes.Remove(dishEntity);
        await dishesDbContext.SaveChangesAsync();
        return TypedResults.NoContent();

    }

}