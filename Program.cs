using GamePortApi.Services;
using GamePortApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<AuthService>();
var app = builder.Build();

app.MapApiEndpoints();
app.UseHttpsRedirection();
app.MapGet("/", () => "Hello, World!");
app.MapPost("/", async (HttpRequest request) =>
{
    var body = await request.ReadFromJsonAsync<Dictionary<string, string>>();
    return Results.Json(body);
});

app.Run();