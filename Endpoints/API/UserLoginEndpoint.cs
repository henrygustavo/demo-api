using Endpoints.Request;
using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic;

namespace Endpoints.API;

[HttpPost("/api/login"), AllowAnonymous]
public class UserLoginEndpoint : Endpoint<LoginRequest>
{
    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        if (await CredentialsAreValid(req.Username, req.Password, ct))
        {
            var jwtToken = JWTBearer.CreateToken(
                signingKey: Domain.Constants.SigningKey,
                expireAt: DateTime.UtcNow.AddDays(1),
                permissions: new[] { "ManageUsers", "ManageInventory" },
                roles: new []{"Manager"},
                claims: new[] {("UserName", req.Username), ("UserID", "001")});

            await SendAsync(new
            {
                Username = req.Username,
                Token = jwtToken
            });
        }
        else
        {
            ThrowError("The supplied credentials are invalid!");
        }
    }

    private async Task<bool> CredentialsAreValid(string reqUsername, string reqPassword, CancellationToken ct)
    {
        return true;
    }
}