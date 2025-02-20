namespace BankCustomers.DTOs
{
    public class CreateTransactionDTO
    {
        public required Guid WalletId { get; set; }
        public required decimal Amount { get; set; }
        public required string Type { get; set; } //"Deposit" or "Withdrawal"
    }

    public class TransactionResponseDTO
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string? Type { get; set; }
        public DateTime Date { get; set; }
    }
}
