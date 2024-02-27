using API_Usage_Fix.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Usage_Fix.Classes {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<UsersModel> Users { get; set; }
    }
}
