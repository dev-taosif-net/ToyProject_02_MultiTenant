using Finbuckle.MultiTenant.Abstractions;
using Infrastructure.Tenancy;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(IMultiTenantContextAccessor<CompanyTenantInfo> multiTenantContextAccessor, DbContextOptions<ApplicationDbContext> options) : base(multiTenantContextAccessor, options)
    {
    }
    
    public DbSet<CompanyTenantInfo> Company { get; set; }
    
}