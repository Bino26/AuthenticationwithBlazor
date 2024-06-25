using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models.DTOs
{
    public class RegisterRequest
    {

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public List<string>? Roles { get; set; }
    }
}
