using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using serenerp_db.Context;

namespace serenerp_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SerenerpDbContext _DbContext;
        public UsersController(SerenerpDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult> HelloWorld()
        {
            var x = await _DbContext.Users.ToListAsync();
            return Ok(new
            {
                Hola = "Mundo"
            });
        }
    }
}
