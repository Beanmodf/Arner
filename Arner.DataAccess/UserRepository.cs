using Arner.DataAccess;
using Arner.DataAccess.Models;
using Arner.Service.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Arner.Service
{
    public class UserRepository : IUserRepository
    {
        private readonly ArnerDbContext _context;
        public UserRepository(ArnerDbContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByName(string name)
        {
            var findUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == name);
            return findUser == null ? null : findUser;
        }

        public async Task<User?> GetUserByID(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.ID == id);
            return user == null ? null : user;
        }

        public async Task<User> Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
