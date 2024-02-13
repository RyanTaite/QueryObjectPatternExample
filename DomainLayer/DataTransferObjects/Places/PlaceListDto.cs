namespace DomainLayer.DataTransferObjects.Places;

public class PlaceListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string State { get; set; }
    public bool IsActive { get; set; }
}