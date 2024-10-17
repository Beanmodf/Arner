using Arner.DataAccess;
using Arner.DataAccess.Models;
using Arner.Service.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            _context.SaveChanges();
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
            var user = await _context.Users.Where(x => x.Username == name).FirstOrDefaultAsync();
            if (user != null) 
            {
                return user;
            } 
            
            return null;
            
        }

        public async Task<User?> GetUserByID(int id)
        {
            var user = await _context.Users.Where(x => x.ID == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            var foundUser = await GetUserByID(user.ID);
            foundUser.Password = user.Password;
            foundUser.UpdatedBy = user.UpdatedBy;
            foundUser.Email =  user.Email;
            foundUser.PhoneNumber = user.PhoneNumber;
            _context.Users.Update(foundUser);
            await _context.SaveChangesAsync();      
            return user;
        }
    }
}
