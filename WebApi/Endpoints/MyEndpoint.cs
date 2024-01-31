namespace Endpoints;
using FastEndpoints;
public class MyRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

public class MyResponse
{
    public string FullName { get; set; }
    public bool IsOver18 { get; set; }
}

public class MyEndpoint : Endpoint<MyRequest, MyResponse>
{
    public override void Configure()
    {
        Post("/api/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(MyRequest req, CancellationToken ct)
    {
        await SendAsync(new()
        {
            FullName = req.FirstName + " " + req.LastName,
            IsOver18 = req.Age > 18
        });
    }
}