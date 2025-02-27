
using GamePortApi.Models;
using GamePortApi.Services;

namespace GameportApi.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/auth/login", async (LoginRequest model, AuthService authService) =>
        {
            var result = await authService.LoginAsync(model);
            return result ? Results.Ok("Login successful") : Results.Unauthorized();
        });
    }
}
