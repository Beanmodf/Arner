using Arner.DataAccess.Models;
using Arner.Service.Helper;
using Arner.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace Arner.Web.API
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

        [HttpPost]
        [ProducesResponseType(404)]
        [ProducesResponseType(201)]

        public async Task<IActionResult> AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var addedUser = await _userService.AddUser(user);
                return StatusCode(StatusCodes.Status201Created, user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error inserting data to database");
            }

        }

        [HttpGet("name/{name}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> GetUserByname(string name)
        {

            var findUser = await _userService.GetUserByName(name);

            if (findUser == null) 
            {
                return NotFound("The user is not existed");
            }

            return Ok(findUser);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var findUser = await _userService.GetUserById(id);

            if (findUser == null)
            {
                return NotFound("The user is not existed");
            }

            return Ok(findUser);
        }
    }

}
