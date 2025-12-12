using System.Reflection;
using Finbuckle.MultiTenant.Abstractions;
using Finbuckle.MultiTenant.Identity.EntityFrameworkCore;
using Infrastructure.Identity.Models;
using Infrastructure.Tenancy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public abstract class BaseDbContext
    : MultiTenantIdentityDbContext<
        ApplicationUser,           // TUser
        ApplicationRole,           // TRole
        string,                    // TKey
        IdentityUserClaim<string>, // TUserClaim
        IdentityUserRole<string>,  // TUserRole
        IdentityUserLogin<string>, // TUserLogin
        ApplicationRoleClaim,      // TRoleClaim 
        IdentityUserToken<string>, // TUserToken
        IdentityUserPasskey<string> // TUserPasskey 
    >
{
    private new CompanyTenantInfo? TenantInfo {get; set;}
    protected BaseDbContext( IMultiTenantContextAccessor<CompanyTenantInfo> multiTenantContextAccessor, DbContextOptions options) : base(multiTenantContextAccessor, options)
    {
        TenantInfo = multiTenantContextAccessor.MultiTenantContext?.TenantInfo;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!string.IsNullOrWhiteSpace(TenantInfo?.ConnectionString))
        {
            optionsBuilder.UseSqlServer(TenantInfo.ConnectionString ,
                options => options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}




