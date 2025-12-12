namespace Domain.Entities;

public class Company
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required DateOnly EstablishedDate { get; set; }
}