using System.Diagnostics;
using API_Usage_Fix.NewFolder;
using Microsoft.AspNetCore.Identity;

namespace API_Usage_Fix.Classes {
    public class UserLoginRegister {
        private static PasswordHasher<string> pwdHasher = new PasswordHasher<string>();

        // CheckUser - checks if provided email/password match info in db 
        public static bool CheckUser(AppDbContext _appDbContext, string email, string password) {
            string storedHash = UsersRepo.CheckUserLogin(_appDbContext, email);

            PasswordVerificationResult passwordCheck = pwdHasher.VerifyHashedPassword(email, storedHash, password);

            if (passwordCheck == PasswordVerificationResult.Success) {
                return true;
            }

            return false;
        }

        // RegisterUser
        public static bool Create(string email, string password) {
            string hashedPwd = pwdHasher.HashPassword(email, password);
            Debug.WriteLine(hashedPwd);

            return true;
        }
    }
}
