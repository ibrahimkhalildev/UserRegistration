using Microsoft.EntityFrameworkCore;
using UserRegistration.Models;

namespace UserRegistration.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public DbSet<User> UserRegistrations { get; set; } 
    }
}
