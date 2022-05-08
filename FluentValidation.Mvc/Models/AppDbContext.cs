using Microsoft.EntityFrameworkCore;

namespace FluentValidation.Mvc.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { //TODO: options'u base'deki yani DbContext'in constructur'una gönderiyoruz.

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
