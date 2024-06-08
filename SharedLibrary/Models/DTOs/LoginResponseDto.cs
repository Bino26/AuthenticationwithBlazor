namespace SharedLibrary.Models.DTOs
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string JwtToken { get; set; }

    }
}
