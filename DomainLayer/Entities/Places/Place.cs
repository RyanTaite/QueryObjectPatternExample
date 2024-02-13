namespace DomainLayer.Entities.Places;

public class Place
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string Name { get; set; }
    public string State { get; set; }
    public bool IsActive { get; set; }
}