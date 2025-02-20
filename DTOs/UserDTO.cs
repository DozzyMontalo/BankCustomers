namespace BankCustomers.DTOs
{
    public class CreateUserDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
    }

    public class UpdateUserDTO
    {
        public required string Address { get; set; }
        public required string Phone { get; set; }
    }
}
