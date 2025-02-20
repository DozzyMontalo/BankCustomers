using BankCustomers.Data;
using Microsoft.AspNetCore.Mvc;
using BankCustomers.DTOs;
using BankCustomers.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankCustomers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        #pragma warning disable IDE0290

        public UserController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO userDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = userDTO.Name,
                Email = userDTO.Email,
                Address = userDTO.Address,
                Phone = userDTO.Phone
            };
            
            context.Users.Add(user);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);  
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(context.Users.ToList());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult>GetUserById(Guid id)
        {
            var user = await context.Users.FindAsync(id);
            if(user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserDTO update)
        {
            var user = await this.context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            user.Address = update.Address;
            user.Phone = update.Phone;

            context.Users.Update(user);
            await this.context.SaveChangesAsync();

            return Ok(user);
        }
    }
}
