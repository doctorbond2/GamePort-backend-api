using GameportApi.Endpoints;

namespace GamePortApi.Endpoints;

public static class ApiEndpoints
{
    public static void MapApiEndpoints(this WebApplication app)
    {
       app.MapAuthEndpoints();
       app.MapUserEndPoints();
    }
}
