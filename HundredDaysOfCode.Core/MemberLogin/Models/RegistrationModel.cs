using System.ComponentModel.DataAnnotations;

namespace HundredDaysOfCode.Core.MemberLogin.Models
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
