using Microsoft.EntityFrameworkCore;
 
namespace BankAccts.Models
{
    public class Context : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<User> users { get; set; }

        public DbSet<Transaction> transactions { get; set; }
    }
}