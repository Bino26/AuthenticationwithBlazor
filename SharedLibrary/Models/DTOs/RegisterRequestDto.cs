using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models.DTOs
{
    public class RegisterRequestDto
    {

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public List<string>? Roles { get; set; }
    }
}
