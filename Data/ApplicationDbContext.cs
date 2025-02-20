using BankCustomers.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace BankCustomers.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wallet>()
                .HasOne(w => w.User)
                .WithMany(u => u.Wallets)
                .HasForeignKey(w => w.UserId);

            modelBuilder.Entity<Transaction>()
               .HasOne(t => t.Wallet)
               .WithMany(w => w.Transactions)
               .HasForeignKey(t => t.WalletId);
        }
    }
}
