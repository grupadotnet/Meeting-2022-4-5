using Microsoft.AspNetCore.Mvc;
using TutorialASP.Models;

namespace TutorialASP.Controllers
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
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetUsers();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var user = await _userService.GetById(id);
            if(user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {
            var user = await _userService.Create(createUserDto);
            return Ok(user);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            try
            {
                var user = await _userService.Update(id, updateUserDto);
                return Ok(user);
            } 
            catch(Exception exception)
            {
                if (exception.Message == "User not found")
                    return NotFound();

                return BadRequest(exception.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
           await _userService.Delete(id);

            return NoContent();
        }


    }
}
