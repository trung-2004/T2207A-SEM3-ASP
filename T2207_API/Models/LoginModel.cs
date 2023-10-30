using System.ComponentModel.DataAnnotations;

namespace T2207A_API.Models
{
    public class LoginModel
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Password { get; set; }
    }
}
