using BankCustomers.Data;
using BankCustomers.DTOs;
using BankCustomers.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BankCustomers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TransactionController  : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public TransactionController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Deposit([FromBody] CreateTransactionDTO transactionDTO)
        {
            var Wallet = await context.Wallets.FindAsync(transactionDTO.WalletId);
            if(Wallet == null)  return NotFound("Wallet not found");

            Wallet.Balance += transactionDTO.Amount;

            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                WalletId = transactionDTO.WalletId,
                Amount = transactionDTO.Amount,
                Type = "Deposit",
                Date = DateTime.UtcNow
            };
            context.Transactions.Add(transaction);
            await context.SaveChangesAsync();

            return Ok(new { Message = "Deposit successful", Balance = Wallet.Balance });
        }
    }
}
