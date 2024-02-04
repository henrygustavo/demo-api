using Endpoints;
using Endpoints.Middleware;
using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpoints.Security;

var bld = WebApplication.CreateBuilder();
bld.Services.AddCors();
bld.Services.AddFastEndpoints(
    o =>
    {
        o.Assemblies = new[] { AssemblyReference.Assembly };
 
    }
    
    ).SwaggerDocument()
    .AddJWTBearerAuth(Domain.Constants.SigningKey) //add this
    .AddAuthorization(); //add this
    ;

var app = bld.Build();
app.UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints(c =>
    {
        c.Endpoints.Configurator = ep =>
        {
            ep.PreProcessor<MyRequestLogger>(Order.Before);
        };
    })
    .UseSwaggerGen()
    .UseCors();
app.Run();