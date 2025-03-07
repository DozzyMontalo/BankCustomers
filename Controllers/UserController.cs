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

            var wallet = new Wallet
            {
                Id = Guid.NewGuid(),
                Address = Guid.NewGuid().ToString(),
                Balance = 0.0m,
                UserId = user.Id
            };

            context.Wallets.Add(wallet);

            await context.SaveChangesAsync();

            var userDTOToReturn = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Address = user.Address,
                Phone = user.Phone,
                Wallets = new List<WalletDTO>
                {
                    new WalletDTO
                    {  
                        UserId = user.Id,
                        Address = wallet.Address,
                        Balance = wallet.Balance
                    }
                }

            }; 


            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, userDTOToReturn);  
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
