namespace DishesAPI.Extensions;

using DishesAPI.EndpointFilters;
using DishesAPI.EndpointHandlers;

public static class EndpointRouteBuilderExtensions
{
    public static void RegisterDishesEndpoints(this IEndpointRouteBuilder builder)
    {
        var dishesEndpoints = builder.MapGroup("/dishes")
            .RequireAuthorization();

        var dishesWithGuidIdEndpoints = dishesEndpoints.MapGroup("/{dishId:guid}");

        var dishesWithGuidIdEndpointsAndLockFilters = builder.MapGroup("/dishes/{dishId:guid}")
            .RequireAuthorization("RequireAdminFromBelgium")
            .AddEndpointFilter(new DishIsLockedFilter(new ("fd630a57-2352-4731-b25c-db9cc7601b16")))
            .AddEndpointFilter(new DishIsLockedFilter(new ("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06")));


        dishesEndpoints.MapGet("", DishesHandlers.GetDishesAsync);

        dishesWithGuidIdEndpoints.MapGet("", DishesHandlers.GetDishesByGuidAsync)
            .WithName("GetDish")
            .WithOpenApi()
            .WithSummary("Get a dish by providing an id")
            .WithDescription("Dishes are identified by a URI containing a dish " +
                "identifier.  This identifier is a GUID.  You can get one specific " +
                "dish via this endpoint by providing the identifer.");
        
        dishesEndpoints.MapGet("/{dishName}", DishesHandlers.GetDishesByNameAsync)
            .AllowAnonymous();
        dishesEndpoints.MapPost("", DishesHandlers.CreateDishAsync)
            .RequireAuthorization("RequireAdminFromBelgium")
            .AddEndpointFilter<ValidateAnnotationsFilter>();
        dishesWithGuidIdEndpointsAndLockFilters.MapPut("", DishesHandlers.UpdateDishAsync);
        dishesWithGuidIdEndpointsAndLockFilters.MapDelete("", DishesHandlers.DeleteDishAsync)
            .AddEndpointFilter<LogNotFoundResponseFilter>();

    }

    public static void RegisterIngredientsEndpoints(this IEndpointRouteBuilder builder)
    {
        var ingredientsEndpoints = builder.MapGroup("/dishes/{dishId:guid}/ingredients")
            .RequireAuthorization();

        ingredientsEndpoints.MapGet("", IngredientsHandlers.GetIngredientsWithDishGuidAsync);
        ingredientsEndpoints.MapPost("", () => {
            throw new NotImplementedException();
        });
    }
    
}
