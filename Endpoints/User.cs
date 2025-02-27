namespace GameportApi.Endpoints;

using GameportApi.Models;

public static class UserEndpoints {
    public static void MapUserEndPoints(this WebApplication app) {
      app.MapGet("/users", (User model ) =>
        {
            return Results.Ok("User list");
        });
    }
}