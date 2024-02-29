using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poke_CRUD_App.Models {
    public class UsersModel {
        [Key]
        public int UserId { get; set; }

        [Column("Email")]
        public string UserEmail { get; set; }


        [Column("PasswordHash")]
        public string UserHashedPwd { get; set; }
    }
}
