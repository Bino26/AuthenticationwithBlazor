namespace Authentication.Client.Authentication
{
    public class AuthenticationModel
    {
        public string JwtToken { get; set; } = null!;

        public string? Username { get; set; }
    }
}
