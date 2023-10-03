
namespace DishesAPI.EndpointFilters;

public class DishIsLockedFilter : IEndpointFilter
{

    readonly Guid _lockedDishId;

    public DishIsLockedFilter(Guid lockedDishId)
    {
        _lockedDishId = lockedDishId;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, 
        EndpointFilterDelegate next)
    {
        //this is just one way to get args.  Can have access to entire request or use GetRouteData or GetRouteValue as well.
        //var dishId = context.GetArgument<Guid>(2); 

        Guid dishId;
        if(context.HttpContext.Request.Method == "PUT")
            dishId = context.GetArgument<Guid>(2);
        else if(context.HttpContext.Request.Method == "DELETE")
            dishId = context.GetArgument<Guid>(1);
        else
        {
            throw new NotSupportedException("This filter is not supported for this scenario");
        }

        if(dishId == _lockedDishId)
        {
            return TypedResults.Problem(new()
            {
                Status = 400,
                Title = "Dish is perfect and cannot be changed",
                Detail = "You cannot update or delete perfection."
            });   
        }


        //invoke the next filter
        var result = await next.Invoke(context);
        return result;
    }
}