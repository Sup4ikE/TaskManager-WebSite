namespace Shared.DTO;

public class RefreshTokenRequestDTO
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public required string RefreshToken { get; set; }
}