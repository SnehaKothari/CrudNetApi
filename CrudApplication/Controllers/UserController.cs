using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using user.Web.Models;
using user.Web.Services;
using user.Web.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using user.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace user.Web.Controllers
{

     [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
       

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        #region GetAllKey
        [HttpGet]
        [Route("api/getallkeys")]
        [ProducesResponseType(200, Type = typeof(Users))]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]


        public async Task<IActionResult> GetAllKeys()
        {
            try
            {
                var result = await _userService.GetAllKeys();
                if (result != null)
                {

                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"UserService::GetAllKeys::GetAllKeys Failed {ex.Message}");
            }

        }
        #endregion

        #region GetKey
        [HttpGet]
        [Route("api/getkeys/{Id}")]
        [ProducesResponseType(200, Type = typeof(Users))]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]


        public async Task<IActionResult> GetKey(int Id)
        {
            try
            {
                var result = await _userService.GetKey(Id);
                if (result != null)
                {

                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"UserService::GetKey::GetKey Failed {ex.Message}");
            }

        }
        #endregion


        #region InsertKey
        [HttpPost]
        [Route("api/insertkeys")]
        [ProducesResponseType(200, Type = typeof(Users))]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]


        public async Task<IActionResult> InsertKeys(Users users)
        {
            try
            {
                var result = await _userService.InsertKeys(users);
                if (result != null)
                {

                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"UserService::InsertKeys::InsertKeys Failed {ex.Message}");
            }

        }
        #endregion

        #region UpdateKey

        [HttpPut]
        [Route("api/updatekeys")]
        [ProducesResponseType(200, Type = typeof(Users))]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]

        public async Task<IActionResult> UpdateKeys(int Id, string Name,string Username, string Email)
          {
              try
              {
                  bool result = await _userService.UpdateKeys(Id,Name,Username, Email);
                  if (result)
                  {
                      return Ok(result);
                  }
                  else
                  {
                      return NoContent();
                  }
              }
              catch (Exception ex)
              {
                  throw new Exception($"UserService::UpdateKeys::UpdateKeys Failed {ex.Message}");
              }
          }
        
     /*   [HttpPut]
        [Route("api/updatekeys/{Id}")]
        [ProducesResponseType(200, Type = typeof(Users))]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
       public async Task<ActionResult<Users>> UpdateKeys(int Id,Users users)
        {
            try {
                if (Id != users.Id)
                {
                    return BadRequest();
                }
                var userUpdate = await _userRepository.GetKey(Id);
                if (userUpdate == null)
                {
                    return NotFound($"Employee with Id={Id} not found");
                }
                else
                {
                    return await _userRepository.UpdateKeys(users);
                }
               // _context.Entry(users).State = EntityState.Modified;
                //await _context.SaveChangesAsync();
                //return NoContent(); // 204 response
            }

            catch (Exception ex)
            {
                throw new Exception($"UserService::InsertKeys::InsertKeys Failed {ex.Message}");
            }
        }



        */
        #endregion

        #region Delete All Keys
        [HttpDelete]
        [Route("api/deleteallkeys")]
        [ProducesResponseType(200, Type = typeof(Users))]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]


        public async Task<IActionResult> DeleteAllKeys()
        {
            try
            {
                bool result = await _userService.DeleteAllKeys();
                if (result != null)
                {

                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"UserService::DeleteAllKeys::DeleteAllKeys Failed {ex.Message}");
            }

        }
        #endregion


        #region Delete Key
        [HttpDelete]
        [Route("api/deletekeys/{Id}")]
        [ProducesResponseType(200, Type = typeof(Users))]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]


        public async Task<IActionResult> DeleteKey(int Id)
        {
            try
            {
                bool result = await _userService.DeleteKey(Id);
                if (result)
                {

                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"UserService::DeleteKeys::DeleteKeys Failed {ex.Message}");
            }

        }
        #endregion


    }
}
