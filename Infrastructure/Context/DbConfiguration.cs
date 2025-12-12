using Domain.Entities;
using Finbuckle.MultiTenant.EntityFrameworkCore.Extensions;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

internal class DbConfiguration
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .ToTable("Users", "Identity")
                .IsMultiTenant();
        }
    }
    
    internal class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ApplicationRole> builder)
        {
            builder
                .ToTable("Roles", "Identity")
                .IsMultiTenant();
        }
    }
    
    internal class IdentityUserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            builder
                .ToTable("UserClaim", "Identity")
                .IsMultiTenant();
        }
    }
    
    internal class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder
                .ToTable("UserRole", "Identity")
                .IsMultiTenant();
        }
    }
    
    internal class LoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<string>>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityUserLogin<string>> builder)
        {
            builder
                .ToTable("Login", "Identity")
                .IsMultiTenant();
        }
    }
    
    
    internal class ApplicationRoleClaimConfiguration : IEntityTypeConfiguration<ApplicationRoleClaim>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ApplicationRoleClaim> builder)
        {
            builder
                .ToTable("RoleClaims", "Identity")
                .IsMultiTenant();
        }
    }
    
    internal class IdentityUserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken<string>>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityUserToken<string>> builder)
        {
            builder
                .ToTable("UserToken", "Identity")
                .IsMultiTenant();
        }
    }
    
    //Shows Error with Passkey
    //Unable to create a 'DbContext' of type 'ApplicationDbContext'. The exception 'The entity type 'IdentityPasskeyData' requires a primary key to be defined. If you intended to use a keyless entity type, call 'HasNoKey' in 'OnModelCreating'. For more information on keyless entity types, see https://go.micr
    // osoft.com/fwlink/?linkid=2141943.' was thrown while attempting to create an instance. For the different patterns supported at design time, 
    // internal class IdentityUserPasskeyConfiguration : IEntityTypeConfiguration<IdentityUserPasskey<string>>
    // {
    //     public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityUserPasskey<string>> builder)
    //     {
    //         builder
    //             .ToTable("UserPasskey", "Identity")
    //             .IsMultiTenant();
    //         
    //         builder.HasKey(x => new { x.UserId});
    //         
    //
    //         // builder.Property(x => x.Id)
    //         //     .ValueGeneratedOnAdd();
    //     }
    // }
    
    internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Company> builder)
        {
            builder
                .ToTable("Companies", "Organization")
                .IsMultiTenant();
            
            builder.Property(x=>x.Name).IsRequired();
            
        }
    }

}