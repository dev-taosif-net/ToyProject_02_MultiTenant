using Finbuckle.MultiTenant.Abstractions;

namespace Infrastructure.Tenancy;

public record CompanyTenantInfo(string Id, string Identifier, string Name) : TenantInfo(Id, Identifier, Name)
{
    public required string ConnectionString { get; init; }
    public required string Email { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public DateTime ValidUntil { get; init; }
    public required bool IsActive { get; set; }

}
