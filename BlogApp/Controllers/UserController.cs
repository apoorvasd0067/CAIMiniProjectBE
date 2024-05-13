using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Context;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _authContext;
        public UserController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_authContext.Users.ToList());
        }

        [HttpPost("authenticate")]
    
        public async Task<IActionResult> Authenticate([FromBody] UserLoginCredentials userObj)
        {
            if (userObj == null)

                return BadRequest();

            var user = await _authContext.Users
                .FirstOrDefaultAsync(x => x.Email == userObj.Email && x.Password == userObj.Password);
            if (user == null)

                return NotFound(new { Message = "User Not Found!" });
            return Ok(new
            {
                Message = "Login Success!"
            });

        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();
            await _authContext.Users.AddAsync(userObj);
            await _authContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Register!"
            });

        }
        [HttpPut]
        [Route("{email}")]

        public IActionResult Update([FromBody] User UserUpdate, [FromRoute] string email)
        {
            var updateuser= _authContext.Users.FirstOrDefault(x => x.Email == email);
            if (UserUpdate == null)
            {
                return NotFound();
            }
            updateuser.Password =UserUpdate.Password;
           
            _authContext.SaveChanges();

            return Ok(updateuser);
        }






    }
}
