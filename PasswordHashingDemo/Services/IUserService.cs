using PasswordHashingDemo.DTO;

namespace PasswordHashingDemo.Services
{
    public interface IUserService
    {
        public void CreateUser(UserDto userDto);

        public bool Login(LoginDto loginDto);
    }
}
