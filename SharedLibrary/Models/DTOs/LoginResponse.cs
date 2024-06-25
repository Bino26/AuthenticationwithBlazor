namespace SharedLibrary.Models.DTOs
{
    public class LoginResponse
    {
        //public UserDto? User { get; set; }
        public string JwtToken { get; set; } = null!;

    }
}
