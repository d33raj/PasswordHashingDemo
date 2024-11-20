using Org.BouncyCastle.Crypto.Generators;
using PasswordHashingDemo.DTO;
using PasswordHashingDemo.Models;
using PasswordHashingDemo.Repositories;

namespace PasswordHashingDemo.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;
        public UserService(IRepository repository)
        {
            _repository = repository;
        }
        public void CreateUser(UserDto userDto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            var user = new User
            {
                UserName = userDto.UserName,
                PasswordHash = hashedPassword,
                Email = userDto.Email
            };
            _repository.AddUser(user);
        }

        public bool Login(LoginDto loginDto)
        {
            var user = _repository.GetUserName(loginDto.UserName);
            if (user != null && BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                return true;
            }
            return false;
        }
    }
}
