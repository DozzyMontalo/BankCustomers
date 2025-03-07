namespace BankCustomers.DTOs
{
    public class CreateWalletDTO
    {
        public required string Address { get; set; }
        //public required decimal Balance { get; set; }
        public required Guid UserId { get; set; }

        public decimal Balance { get; set; }
    }

    public class WalletBalanceDTO
    {
        public required Guid WalletId { get; set; }
        public decimal Balance { get; set; }
    }

    public class WalletDTO
    {
        public string ? Address { get; set; }
        
        public Guid UserId { get; set; }

        public decimal Balance { get; set; }
    }

}
