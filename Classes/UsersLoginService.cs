using Microsoft.AspNetCore.Identity;
using Poke_CRUD_App.NewFolder;

namespace Poke_CRUD_App.Classes {
    public class UsersLoginService {
        private static PasswordHasher<string> pwdHasher = new PasswordHasher<string>();

        // CheckUser - checks if provided email/password match info in db 
        public static bool CheckUserLogin(AppDbContext _appDbContext, string email, string password) {
            string storedHash = UsersRepo.GetUserPassword(_appDbContext, email);

            PasswordVerificationResult passwordCheck = pwdHasher.VerifyHashedPassword(email, storedHash, password);

            if (passwordCheck == PasswordVerificationResult.Success) {
                return true;
            }

            return false;
        }

        // RegisterUser - registers user in the db
        public static bool RegisterUser(AppDbContext _appDbContext, string email, string password) {
            string hashedPwd = pwdHasher.HashPassword(email, password);

            UsersRepo.CreateUserRecord(_appDbContext, email, hashedPwd);

            return true;
        }
    }
}
