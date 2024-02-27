using API_Usage_Fix.Classes;
using API_Usage_Fix.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Usage_Fix.NewFolder {
    public class UsersRepo {

        public static string CheckUserLogin(AppDbContext _appDbContext, string email) {
            List<UsersModel> hashedPwd = _appDbContext.Users.FromSql($"SELECT * FROM dbo.Users WHERE Email = {email}").ToList();

            return hashedPwd[0].UserHashedPwd;
        }
    }
}
