using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Controllers.Models;

namespace WebApplication1.Controllers
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



        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if(userObj  == null)
            {
                return BadRequest();
            }
            var user = await _authContext.Users.FirstOrDefaultAsync(x => x.Email == userObj.Email && x.Password == userObj.Password);
            if (user == null) {
                return NotFound(new { Message = "User Not Found!" });
            }
            return Ok(new
            {
                Message="login Success"
            });
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userOb)
        {
            if(userOb == null)
            {
                return BadRequest();
            }
            await _authContext.Users.AddAsync(userOb);
            await _authContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "user registerd!"
            });
        }

        /*.........................................................*/
        

    }
}
