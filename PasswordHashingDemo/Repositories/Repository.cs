using PasswordHashingDemo.Data;
using PasswordHashingDemo.Models;

namespace PasswordHashingDemo.Repositories
{
    public class Repository : IRepository
    {
        private readonly UserContext _context;
        public Repository(UserContext context)
        {
            _context = context;
            //users = new List<User>();
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUserName(string name)
        {
            return _context.Users.Where(u => u.UserName == name).FirstOrDefault();
        }
    }
}
