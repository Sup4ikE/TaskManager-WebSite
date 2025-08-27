using Shared.Models;
namespace Shared.DTO;

public class AuthResponseDTO
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    
    public User User { get; set; } = null!;
}