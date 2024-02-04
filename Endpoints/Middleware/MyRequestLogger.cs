using FastEndpoints;
using Microsoft.Extensions.Logging;

namespace Endpoints.Middleware;

public class MyRequestLogger : IGlobalPreProcessor
{
    public Task PreProcessAsync(IPreProcessorContext ctx, CancellationToken ct)
    {
        var logger = ctx.HttpContext.Resolve<ILogger<MyRequestLogger>>();

        logger.LogInformation(
            $"request:{ctx.Request.GetType().FullName} path: {ctx.HttpContext.Request.Path}");

        return Task.CompletedTask;
    }
}