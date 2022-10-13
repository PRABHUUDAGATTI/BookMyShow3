using Book_Show_BLL.Services;
using Book_Show_Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserServices _UserServices;
        public UserController(UserServices userServices)
        {
            _UserServices = userServices;
        }
        [HttpGet("GetUser")]
        public IEnumerable<UserDetails> GetUserDetails()
        {
            return _UserServices.GetAll();
        }
        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] UserDetails User)
        {
            _UserServices.AddUserDetails(User);
            return Ok("User added succesfully");
        }
        [HttpDelete("DeletdUser")]
        public IActionResult DeleteMovies(int movieId)
        {
            _UserServices.DeleteUserDetails(movieId);
            return Ok("User Delete Succesfully");
        }
        [HttpPut("UpdateUser")]
        public IActionResult UpdateMovies([FromBody] UserDetails User)
        {
            _UserServices.UpdateUserDetails(User);
            return Ok("User Upadted Succesfully");
        }
    }
}
