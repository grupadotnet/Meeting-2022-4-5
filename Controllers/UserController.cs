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
            var users = _userService.GetUsers();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var user = _userService.GetById(id);
            if(user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {
            var user = _userService.Create(createUserDto);
            return Ok(user);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            try
            {
                var user = _userService.Update(id, updateUserDto);
                return Ok(user);
            } 
            catch(Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            _userService.Delete(id);

            return NoContent();
        }


    }
}
