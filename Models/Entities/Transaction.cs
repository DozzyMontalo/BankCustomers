namespace BankCustomers.Models.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required decimal Amount { get; set; }
        public required string Type { get; set; } //"Deposit" or "Withdrawal"
        public DateTime Date { get; set; } = DateTime.UtcNow;

        // Foreign key reference to Wallet
        public required Guid WalletId { get; set; }
        public required Wallet? Wallet { get; set; }  // Navigation property (nullable)

    }
}
