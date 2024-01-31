using Endpoints;
using FastEndpoints;
using FastEndpoints.Swagger;

var bld = WebApplication.CreateBuilder();
bld.Services.AddCors();
bld.Services.AddFastEndpoints(
    o =>
    {
        o.Assemblies = new[] { AssemblyReference.Assembly };
    }
    ).SwaggerDocument();;

var app = bld.Build();
app.UseFastEndpoints()
    .UseSwaggerGen()
    .UseCors();
app.Run();