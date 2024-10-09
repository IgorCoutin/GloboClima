using Microsoft.AspNetCore.Identity;
using GloboClima.API.Models;

namespace GloboClima.API.Services
{
    public class PasswordService
    {
        private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public string HashPassword(User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public bool VerifyPassword(User user, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.senha, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
