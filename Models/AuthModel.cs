namespace GamePortApi.Models
{
    // This class represents the structure of the login request
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
