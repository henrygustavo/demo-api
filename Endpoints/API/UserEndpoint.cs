using Carter;
using Endpoints.Response;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Endpoints.API;
public class UserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/users", (string id) => 
            Results.Ok( new UserResponse("Henry", true)));
    }
}