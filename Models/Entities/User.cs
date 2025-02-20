namespace BankCustomers.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public  required string Phone { get; set; }

        public List<Wallet>? Wallets { get; set; }
    }
}
