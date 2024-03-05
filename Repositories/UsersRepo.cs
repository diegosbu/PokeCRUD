using Microsoft.EntityFrameworkCore;
using Poke_CRUD_App.Classes;
using Poke_CRUD_App.Models;

namespace Poke_CRUD_App.NewFolder {
    public class UsersRepo {

        public static string GetUserPassword(AppDbContext _appDbContext, string email) {
            List<UsersModel> hashedPwd = _appDbContext.Users.FromSql($"SELECT * FROM dbo.Users WHERE Email = {email}").ToList();

            if (hashedPwd.Any()) {
                return hashedPwd[0].UserHashedPwd;
            }
                
            return "";
        }

        public static void CreateUserRecord(AppDbContext _appDbContext, string email, string hashedPwd) {
            _appDbContext.Users.FromSql($"INSERT INTO dbo.Users(Email, PasswordHash) VALUES({email}, {hashedPwd})");
        }
    }
}
