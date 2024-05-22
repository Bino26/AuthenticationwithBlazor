using System.ComponentModel.DataAnnotations;

namespace Authentication.API.Models.DTOs
{
    public class RegisterRequestDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must contains 3 characters")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public List <string>? Roles { get; set; }
    }
}
