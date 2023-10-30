using System.ComponentModel.DataAnnotations;

namespace T2207A_API.Models.User
{
    public class UserRegister
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string fullname { get; set; }
        [Required]
        [MinLength(6)]
        public string password { get; set; }
    }
}
