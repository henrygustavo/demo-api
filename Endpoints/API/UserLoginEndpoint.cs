using Carter;
using Endpoints.Request;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Endpoints.API;

public class UserLoginEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/users", (LoginRequest req) => Results.Ok(new
        {
            Username = req.Username,
            Token = "abc"
        }));
    }
}