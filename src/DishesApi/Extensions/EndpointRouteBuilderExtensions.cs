namespace DishesAPI.Extensions;

using DishesAPI.EndpointFilters;
using DishesAPI.EndpointHandlers;

public static class EndpointRouteBuilderExtensions
{
    public static void RegisterDishesEndpoints(this IEndpointRouteBuilder builder)
    {
        var dishesEndpoints = builder.MapGroup("/dishes");
        var dishesWithGuidIdEndpoints = dishesEndpoints.MapGroup("/{dishId:guid}");

        var dishesWithGuidIdEndpointsAndLockFilters = builder.MapGroup("/dishes/{dishId:guid}")
            .AddEndpointFilter(new DishIsLockedFilter(new ("fd630a57-2352-4731-b25c-db9cc7601b16")))
            .AddEndpointFilter(new DishIsLockedFilter(new ("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06")));


        dishesEndpoints.MapGet("", DishesHandlers.GetDishesAsync);
        dishesWithGuidIdEndpoints.MapGet("", DishesHandlers.GetDishesByGuidAsync).WithName("GetDish");
        dishesEndpoints.MapGet("/{dishName}", DishesHandlers.GetDishesByNameAsync);
        dishesEndpoints.MapPost("", DishesHandlers.CreateDishAsync);
        dishesWithGuidIdEndpointsAndLockFilters.MapPut("", DishesHandlers.UpdateDishAsync);
        dishesWithGuidIdEndpointsAndLockFilters.MapDelete("", DishesHandlers.DeleteDishAsync);

    }

    public static void RegisterIngredientsEndpoints(this IEndpointRouteBuilder builder)
    {
        var ingredientsEndpoints = builder.MapGroup("/dishes/{dishId:guid}/ingredients");

        ingredientsEndpoints.MapGet("", IngredientsHandlers.GetIngredientsWithDishGuidAsync);
        ingredientsEndpoints.MapPost("", () => {
            throw new NotImplementedException();
        });
    }
    
}
