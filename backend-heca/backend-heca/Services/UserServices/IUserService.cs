using backend_heca.Models;

namespace backend_heca.Services.UserServices
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetSingleUser(int id);
        Task<User> AddUser(User user);
        Task<User>? UpdateUser(int id, User request);
        Task<User>? DeleteUser(int id);
    }
}
