using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public bool IsActive { get; set; } = true;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiryTime { get; set; }
    
}