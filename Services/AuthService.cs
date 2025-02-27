using System.Threading.Tasks;
using GameportApi.Models;
using GamePortApi.Models;

namespace GamePortApi.Services;

public class AuthService
{
    public async Task<bool> LoginAsync(LoginRequest model)
    {
        // Mock authentication logic (replace with database check)
        return await Task.FromResult(model.Username == "admin" && model.Password == "password");
    }
}
