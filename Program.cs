using GamePortApi.Services;
using GamePortApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<AuthService>();


builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();


app.UseCors("AllowAll");  // ✅ Must be before UseRouting and MapControllers
app.UseRouting();         // ✅ Ensures correct request processing
app.UseAuthorization();   // ✅ Handles auth before hitting endpoints


app.MapControllers(); 
;

app.MapGet("/", () => "Hello, World!");
app.MapPost("/", async (HttpRequest request) =>
{
    var body = await request.ReadFromJsonAsync<Dictionary<string, string>>();
    return Results.Json(body);
});

app.Run();
