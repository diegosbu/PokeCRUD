using Microsoft.EntityFrameworkCore;
using Poke_CRUD_App.Models;

namespace Poke_CRUD_App.Classes {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<UsersModel> Users { get; set; }
    }
}
