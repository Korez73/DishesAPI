
using System.Net;

namespace DishesAPI.EndpointHandlers;

public class LogNotFoundResponseFilter : IEndpointFilter
{

    readonly ILogger<LogNotFoundResponseFilter> _logger;

    public LogNotFoundResponseFilter(ILogger<LogNotFoundResponseFilter> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var result = await next(context);
        //we can't do this, becuase the return types from our endpoint handlers are INestedHttpResult
        //var castedResult = result as IStatusCodeHttpResult;
        var actualResult = (result is INestedHttpResult) ? ((INestedHttpResult)result).Result : (IResult)result;

        if((actualResult as IStatusCodeHttpResult)?.StatusCode == (int)HttpStatusCode.NotFound)
        {
            _logger.LogInformation($"Resource {context.HttpContext.Request.Path} was not found.");
        }

        return result;

    }
}