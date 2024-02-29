using Microsoft.EntityFrameworkCore;
using Poke_CRUD_App.Classes;
using Poke_CRUD_App.Models;

namespace Poke_CRUD_App.NewFolder {
    public class UsersRepo {

        public static string CheckUserLogin(AppDbContext _appDbContext, string email) {
            List<UsersModel> hashedPwd = _appDbContext.Users.FromSql($"SELECT * FROM dbo.Users WHERE Email = {email}").ToList();

            return hashedPwd[0].UserHashedPwd;
        }
    }
}
