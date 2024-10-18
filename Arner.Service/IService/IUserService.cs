using Arner.DataAccess.Models;

namespace Arner.Service.IService
{
    public interface IUserService
    {
        Task<User?> AddUser(User user);
        Task<User?> GetUserByName(string name);
        Task<User?> GetUserById(int id); 
    }
}
