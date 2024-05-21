namespace Authentication.API.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateJwtTokenAsync(string userName, IList<string> roles);
    }
}
