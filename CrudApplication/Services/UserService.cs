using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using user.Web.Data;
using user.Web.Models;
using user.Web.Repository;
using user.Web.Services;

namespace user.Web.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Users>> GetAllKeys()
        {
            try
            {
                return await _userRepository.GetAllKeys();
            }
            catch (NpgsqlException ex)
            {
                throw new Exception($"UserService::GetAllKeys::GetAllKeys Failed {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"UserService::GetAllKeys::GetAllKeys Failed {ex.Message}");
            }
        }

        public async Task<IEnumerable<Users>> GetKey(int Id)
        {
            try
            {
                return await _userRepository.GetKey(Id);
            }
            catch (NpgsqlException ex)
            {
                throw new Exception($"UserService::GetKey::GetKey Failed {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"UserService::GetKey::GetKey Failed {ex.Message}");
            }
        }

        public async Task<bool> InsertKeys(Users users)
        {
            try
            {
                return await _userRepository.InsertKeys(users);
            }
            catch (NpgsqlException ex)
            {
                throw new Exception($"UserService::InsertKeys::InsertKeys Failed {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"UserService::InsertKeys::InsertKeys Failed {ex.Message}");
            }
        }


        public async Task<bool> UpdateKeys(int Id,string Name,string Username, string Email)
        {
            try
            {
                return await _userRepository.UpdateKeys(Id,Name,Username, Email);
            }
            catch (NpgsqlException ex)
            {
                throw new Exception($"UserService::UpdatetKeys Failed {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"UserService::UpdateKeys Failed {ex.Message}");
            }
        }


        /*public async Task UpdateKeys(int Id,Users users)
        {
            var user = await _context.users.FindAsync(Id);
            if (user != null)
            {
                user.Name = users.Name;
                user.Email = users.Email;

                 await _context.SaveChangesAsync();
            }
        }
        */
        public async Task<bool> DeleteKey(int Id)
        {
            try
            {
                return await _userRepository.DeleteKey(Id);
            }
            catch (NpgsqlException ex)
            {
                throw new Exception($"UserService::DeleteKey::DeleteKey Failed {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"UserService::DeleteKey::DeleteKey Failed {ex.Message}");
            }
        }

        public async Task<bool> DeleteAllKeys()
        {
            try
            {
                return await _userRepository.DeleteAllKeys();
            }
            catch (NpgsqlException ex)
            {
                throw new Exception($"UserService::DeleteAllKeys::DeleteAllKeys Failed {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"UserService::DeleteAllKeys::DeleteAllKeys Failed {ex.Message}");
            }
        }


    }
}

