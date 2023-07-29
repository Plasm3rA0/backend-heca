using backend_heca.Data;
using backend_heca.Models;

namespace backend_heca.Services.UserServices
{
    public class UserService : IUserService
    {
        public readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User>? DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetSingleUser(int id)
        {
            User user = await  _context.Users.FindAsync(id);
            if (user == null) return null;
            return user;
        }

        public async Task<User>? UpdateUser(int id, User request)
        {
            var user = await _context.Users.FindAsync(id);
            if (request.Equals(user) || request == null) return null;

            user.uname = request.uname;
            user.password = request.password;
            user.firstName = request.firstName;
            user.lastName = request.lastName;
            user.email = request.email;
            user.phone = request.phone;

            await _context.SaveChangesAsync();

            return user;

            
        }
    }
}
