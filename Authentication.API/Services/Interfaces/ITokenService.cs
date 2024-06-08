namespace Authentication.API.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateJwtTokenAsync(string Email, IList<string> roles);
    }
}
