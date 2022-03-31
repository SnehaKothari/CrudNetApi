using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using user.Web.Models;

namespace TestData
{
    public class Test
    {
        public static async Task<IEnumerable<Users>> GetAllKeys()
        {
            List<Users> data = new List<Users>
            {
                new Users
                {
                    Id=1,
                    Name="Sneha Kothari",
                    Username="sneha",
                    Email="kothari.sneha05@gmail.com"
                },
                new Users
                {
                     Id=2,
                    Name="Anjali Kothari",
                    Username="anju",
                    Email="anju@gmail.com"
                }
            };
            return await Task.FromResult<IList<Users>>(data);
        }

        public static async Task<IEnumerable<Users>> GetAllKeys_NoContent()
        {
            List<Users> data = new List<Users> { };
            return await Task.FromResult<IList<Users>>(data);
        }

        public static async Task<IEnumerable<Users>> GetKey()
        {
            List<Users> data = new List<Users>
            {
                new Users
                {
                    Id=1,
                    Name="Sneha Kothari",
                    Username="sneha",
                    Email="kothari.sneha05@gmail.com"
                }

            };
            return await Task.FromResult<IList<Users>>(data);
        }

        public static async Task<IEnumerable<Users>> GetKey_NoContent()
        {
            List<Users> data = new List<Users> { };
            return await Task.FromResult<IList<Users>>(data);
        }

    }
}