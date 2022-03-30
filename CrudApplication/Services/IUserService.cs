using System.Collections.Generic;
using System.Threading.Tasks;
using user.Web.Models;

namespace user.Web.Services
{
    public interface IUserService
    {
        Task<IEnumerable<Users>> GetAllKeys();
        Task<IEnumerable<Users>> GetKey(int Id);
        Task<bool> InsertKeys(Users users);
        Task<bool> UpdateKeys(int Id,string Name,string Username, string Email);
        Task<bool> DeleteAllKeys();
        Task<bool> DeleteKey(int Id);
        

       
    }
}
