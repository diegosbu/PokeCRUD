using System.ComponentModel.DataAnnotations;

namespace API_Usage_Fix.Models {
    public class UsersModel {
        [Key]
        public string? UserId { get; set; }

        public string? UserEmail { get; set; }

        public string? UserHashedPwd { get; set; }
    }
}
