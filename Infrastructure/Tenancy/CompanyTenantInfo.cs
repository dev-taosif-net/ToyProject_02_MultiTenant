using Finbuckle.MultiTenant.Abstractions;

namespace Infrastructure.Tenancy;

public record CompanyTenantInfo(string Id, string Identifier, string Name) : TenantInfo(Id, Identifier, Name)
{
    public required string ConnectionString { get; set; }
    public required string Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime ValidUntil { get; set; }
    public required bool IsActive { get; set; }

}
