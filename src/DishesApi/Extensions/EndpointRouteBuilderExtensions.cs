namespace DishesAPI.Extensions;
using DishesAPI.EndpointHandlers;

public static class EndpointRouteBuilderExtensions
{
    public static void RegisterDishesEndpoints(this IEndpointRouteBuilder builder)
    {
        var dishesEndpoints = builder.MapGroup("/dishes");
        var dishesWithGuidIdEndpoints = dishesEndpoints.MapGroup("/{dishId:guid}");

        dishesEndpoints.MapGet("", DishesHandlers.GetDishesAsync);
        dishesWithGuidIdEndpoints.MapGet("", DishesHandlers.GetDishesByGuidAsync).WithName("GetDish");
        dishesEndpoints.MapGet("/{dishName}", DishesHandlers.GetDishesByNameAsync);
        dishesEndpoints.MapPost("", DishesHandlers.CreateDishAsync);
        dishesWithGuidIdEndpoints.MapPut("", DishesHandlers.UpdateDishAsync);
        dishesWithGuidIdEndpoints.MapDelete("", DishesHandlers.DeleteDishAsync);
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
