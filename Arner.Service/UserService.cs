using Arner.DataAccess.Models;
using Arner.Service.IRepository;
using Arner.Service.IService;

namespace Arner.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User?> AddUser(User user)
        {
            var findUser = await _userRepo.GetUserByName(user.Username);

            if (findUser != null)
            {
                return null;
            }

            return await _userRepo.Add(user);
        }

    }

}
