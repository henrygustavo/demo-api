using Endpoints.Request;
using Endpoints.Response;
using FastEndpoints;

namespace Endpoints.API;

public class UserEndpoint : Endpoint<UserRequest, UserResponse>
{
    public override void Configure()
    {
        Post("/api/users");
        //AllowAnonymous();
    }

    public override async Task HandleAsync(UserRequest req, CancellationToken ct)
    {
        await SendAsync(new UserResponse($"{req.FirstName} {req.LastName}", req.Age > 18)
            , cancellation: ct);
    }
}