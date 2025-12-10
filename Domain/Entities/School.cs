namespace Domain.Entities;

public class School
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required DateOnly EstablishedDate { get; set; }
}