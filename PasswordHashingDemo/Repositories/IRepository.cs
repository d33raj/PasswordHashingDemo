using PasswordHashingDemo.Models;

namespace PasswordHashingDemo.Repositories
{
    public interface IRepository
    {
        public void AddUser(User user);
        public User GetUserName(string name);
    }
}
