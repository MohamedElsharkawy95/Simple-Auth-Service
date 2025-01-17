using Microsoft.AspNetCore.Identity;

namespace AuthAPI.Models;

public class User : IdentityUser
{
    public required string FullName { get; set; }
    public int? UserTypeId { get; set; }
    public UserType UserType { get; set; } = null!;
}
