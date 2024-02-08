using Carter;

var bld = WebApplication.CreateBuilder();
bld.Services.AddCarter();
bld.Services.AddEndpointsApiExplorer();
bld.Services.AddSwaggerGen();

var app = bld.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapCarter();

app.Run();