using DomainLayer.DataTransferObjects.Places;
using DomainLayer.Infrastructure.Persistence.QueryObjects.Places;

namespace ServiceLayer.Place;

public class PlaceService : IPlaceService
{
    private readonly List<DomainLayer.Entities.Places.Place> _placesContext;
    
    public PlaceService(IEnumerable<DomainLayer.Entities.Places.Place> placesContext)
    {
        _placesContext = placesContext.ToList();
    }

    public List<PlaceListDto> GetPlaceListDtos(PlacesFilter placesFilter, PlacesSort placesSort)
    {
        var result = _placesContext
            .AsQueryable()
            .SelectPlacesForList()
            .FilterPlaces(placesFilter)
            .SortPlaces(placesSort)
            .ToList();

        return result;
    }
}