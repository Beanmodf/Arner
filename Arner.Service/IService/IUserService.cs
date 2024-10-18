using Arner.DataAccess.Models;

namespace Arner.Service.IService
{
    public interface IUserService
    {
        Task<User?> AddUser(User user);
    }
}
