using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using ShopWebApiProject.Data;
using ShopWebApiProject.Models;

namespace ShopWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ShopeDbContext shopeDbContext;
        public UsersController(ShopeDbContext shopeDbContext)
        {
            this.shopeDbContext = shopeDbContext;
            
        }
        [HttpPost]
        [Route("/add")]
        public async Task<IActionResult> CreateUser(User user )
        {
            await shopeDbContext.Users.AddAsync( user );
            await  shopeDbContext.SaveChangesAsync();
            return Ok( user );

        }
        [HttpGet]
        [Route("/Users")]
        public async Task<IActionResult> GetUser()
        {
            List<User>Users=await shopeDbContext.Users.ToListAsync();
            return Ok(Users);
        }
        [HttpGet]
        [Route("/Users/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            User FoundUser = await shopeDbContext.Users
                .Include(o => o.Orders)
                .FirstOrDefaultAsync(u => u.Id == id);           
                if ( FoundUser == null ) 
            {
               return NotFound();
            }
            else
            {
                return Ok( FoundUser );
            }
        }
        [HttpPost]
        [Route("/Update/{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute ]int id,User UpdatedUser)
        {
            User ExistingUser = await shopeDbContext.Users.FindAsync(id);

            if (ExistingUser != null) 
            {
             ExistingUser.Name=UpdatedUser.Name;
                ExistingUser.Email=UpdatedUser.Email;
                ExistingUser.City=UpdatedUser.City;
                shopeDbContext.Update(ExistingUser);
                shopeDbContext.SaveChanges();

            return Ok(ExistingUser);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete]
        [Route("/Deleted/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id, User DeletedUser)
        {
            User FoundUser = await shopeDbContext.Users.FindAsync(id);
            if (FoundUser == null)
            {
               

                return NotFound();
            }
            else
            {
                shopeDbContext.Remove(FoundUser);
                shopeDbContext.SaveChanges();

                return Ok(id +"deleted");
            }
        }
    }
}
