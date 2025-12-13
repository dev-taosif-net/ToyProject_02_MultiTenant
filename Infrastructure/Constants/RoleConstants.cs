namespace Infrastructure.Constants;

public static class RoleConstants
{
    public const string Admin = nameof(Admin);
    public const string Basic = nameof(Basic);
    
    public static IReadOnlyList<string> DefaultRoles = new List<string>
    {
        Admin,
        Basic
    };
    
    public static bool IsDefaultRole(string roleName)
    {
        return DefaultRoles.Contains(roleName);
    }
    
}