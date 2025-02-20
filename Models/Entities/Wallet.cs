namespace BankCustomers.Models.Entities
{
    public class Wallet
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Address { get; set; }
        public required decimal Balance { get; set; }

        // Foreign key reference to User
        public required Guid UserId { get; set; }
        public  User? User { get; set; } // Navigation property (nullable)
        public List<Transaction>? Transactions { get; set; }
    }
}
