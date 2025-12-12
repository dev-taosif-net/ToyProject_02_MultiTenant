using Finbuckle.MultiTenant.AspNetCore.Extensions;
using Finbuckle.MultiTenant.EntityFrameworkCore.Extensions;
using Finbuckle.MultiTenant.Extensions;
using Infrastructure.Tenancy;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class StartUp
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDbContext<TenantDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
            .AddMultiTenant<CompanyTenantInfo>()
            .WithHeaderStrategy(TenancyConstants.TenantIdName)
            .WithClaimStrategy(TenancyConstants.TenantIdName)
            .WithEFCoreStore<TenantDbContext, CompanyTenantInfo>()
            .Services;

    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        return app.UseMultiTenant();
    }
}