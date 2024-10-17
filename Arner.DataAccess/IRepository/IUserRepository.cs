using Arner.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arner.Service.IRepository
{
    public interface IUserRepository 
    {
        Task<User?> GetUserByName(string name);
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task<User> Delete(User user);
        Task<User?> GetUserByID(int id);
        
    }
}
