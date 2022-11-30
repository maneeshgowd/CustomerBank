using CustomerBank.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerBank.Data
{
    public class CustomerStoreContext : DbContext
    {
        public DbSet<CustomerModel> Customer { get; set; }
        public DbSet<AccountModel> Account { get; set; }

        public CustomerStoreContext(DbContextOptions<CustomerStoreContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountModel>().HasKey(b => b.AccountNumber);
            modelBuilder.Entity<CustomerModel>().HasKey(b => b.CustomerId);
        }
     
    }
}
