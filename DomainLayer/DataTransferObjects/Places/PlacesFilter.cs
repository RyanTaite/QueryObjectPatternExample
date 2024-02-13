namespace DomainLayer.DataTransferObjects.Places;

public class PlacesFilter
{
    public string Name { get; set; }
    public string State { get; set; }
    public bool IncludeInactive { get; set; }
}