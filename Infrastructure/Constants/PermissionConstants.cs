namespace Infrastructure.Constants;

public static class PermissionConstants
{

}

public static class CompanyActions
{
    public const string Read = nameof(Read);
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
    public const string UpgradeSubscription = nameof(UpgradeSubscription);
}


public static class CompanyFeatures
{
    public const string Tenants = nameof(Tenants);
    public const string Users = nameof(Users);
    public const string UserRoles = nameof(UserRoles);
    public const string Role = nameof(Role);
    public const string RoleClaims = nameof(RoleClaims);
    public const string Company = nameof(Company);
}

public record CompanyPermission(string Action , string Feature , string Description , string Group , bool IsBasic = false , bool IsRoot = false)
{
    public string Name => NameFor(Action , Feature) ;
    private static string NameFor(string action, string feature) => $"Permission,{feature}.{action}";

}

public static class CompanyPermissionList
{
    private static readonly List<CompanyPermission> CompanyPermissions =
    [
        new CompanyPermission(CompanyActions.Read, CompanyFeatures.Tenants, "Read Tenants","Tenancy" , IsRoot: true),
        new CompanyPermission(CompanyActions.Create, CompanyFeatures.Tenants, "Create Tenants","Tenancy" , IsRoot: true),
        new CompanyPermission(CompanyActions.Update, CompanyFeatures.Tenants, "Update Tenants","Tenancy" , IsRoot: true),
        new CompanyPermission(CompanyActions.Delete, CompanyFeatures.Tenants, "Delete Tenants","Tenancy" , IsRoot: true),
        new CompanyPermission(CompanyActions.UpgradeSubscription, CompanyFeatures.Tenants, "Upgrade Tenants Subscription","Tenancy" , IsRoot: true) ,

        new CompanyPermission(CompanyActions.Read, CompanyFeatures.Users, "Read Users","SystemAccess" ,  IsRoot: false),
        new CompanyPermission(CompanyActions.Create, CompanyFeatures.Users, "Create Users","SystemAccess" , IsRoot: false),
        new CompanyPermission(CompanyActions.Update, CompanyFeatures.Users, "Update Users","SystemAccess" , IsRoot: false),
        new CompanyPermission(CompanyActions.Delete, CompanyFeatures.Users, "Delete Users","SystemAccess" , IsRoot: false),
        
        new CompanyPermission(CompanyActions.Read, CompanyFeatures.UserRoles, "Read User Roles","SystemAccess" , IsRoot: false),
        // new CompanyPermission(CompanyActions.Create, CompanyFeatures.UserRoles, "Create User Roles", IsRoot: true),
        new CompanyPermission(CompanyActions.Update, CompanyFeatures.UserRoles, "Update User Roles","SystemAccess" , IsRoot: false),
        // new CompanyPermission(CompanyActions.Delete, CompanyFeatures.UserRoles, "Delete User Roles", IsRoot: true),
        
        new CompanyPermission(CompanyActions.Read, CompanyFeatures.Role, "Read Roles","SystemAccess" ,  IsRoot: false),
        new CompanyPermission(CompanyActions.Create, CompanyFeatures.Role, "Create Roles", "SystemAccess" ,IsRoot: false),
        new CompanyPermission(CompanyActions.Update, CompanyFeatures.Role, "Update Roles","SystemAccess" , IsRoot: false),
        new CompanyPermission(CompanyActions.Delete, CompanyFeatures.Role, "Delete Roles","SystemAccess" , IsRoot: false),
        
        new CompanyPermission(CompanyActions.Read, CompanyFeatures.RoleClaims, "Read Role Claims","SystemAccess" , IsRoot: false),
        // new CompanyPermission(CompanyActions.Create, CompanyFeatures.RoleClaims, "Create Role Claims", IsRoot: true),
        new CompanyPermission(CompanyActions.Update, CompanyFeatures.RoleClaims, "Update Role Claims","SystemAccess" , IsRoot: false),
        // new CompanyPermission(CompanyActions.Delete, CompanyFeatures.RoleClaims, "Delete Role Claims", IsRoot: true),
        
        new CompanyPermission(CompanyActions.Read, CompanyFeatures.Company, "Read Companies","Organization" , IsBasic: true ,  IsRoot: false),
        new CompanyPermission(CompanyActions.Create, CompanyFeatures.Company, "Create Companies","Organization" , IsRoot: false),
        new CompanyPermission(CompanyActions.Update, CompanyFeatures.Company, "Update Companies","Organization" , IsRoot: false),
        new CompanyPermission(CompanyActions.Delete, CompanyFeatures.Company, "Delete Companies","Organization" , IsRoot: false),

    ];
    
    public static IReadOnlyList<CompanyPermission> All => new List<CompanyPermission>(CompanyPermissions);
    public static IReadOnlyList<CompanyPermission> Root => new List<CompanyPermission>(CompanyPermissions.Where(x=>x.IsRoot ));
    public static IReadOnlyList<CompanyPermission> Admin => new List<CompanyPermission>(CompanyPermissions.Where(x=>!x.IsRoot ));
    public static IReadOnlyList<CompanyPermission> Basic => new List<CompanyPermission>(CompanyPermissions.Where(x=>x.IsBasic ));
    
    
    
    
}




