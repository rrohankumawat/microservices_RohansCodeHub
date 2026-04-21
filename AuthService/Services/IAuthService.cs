using AuthService.Entities;

namespace AuthService.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(string email, string password);
        Task<User> GetUserByEmail(string email);
    }
}
