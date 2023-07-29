using backend_heca.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_heca.Controllers
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

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var res = await _userService.GetAllUsers();
            if (res == null) return BadRequest("There is no Users in our database.");
            return Ok(res);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<User>> GetSingleUser(int id)
        {
            var res = await _userService.GetSingleUser(id);
            if (res == null) return NotFound("This user is not in our list of users.");
            return Ok(res);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            var res = await _userService.AddUser(user);
            if (res == null) return BadRequest("We could not create that user, please verify the information.");
            return Ok(res);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            var res = await _userService.UpdateUser(id, user);
            if (res == null) return BadRequest("Error updating the user with ID: " + id);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var res = await _userService.DeleteUser(id);
            if (res == null) return BadRequest("Error deleting the user with ID: " + id);
            return Ok(res);
        }
    }
}
