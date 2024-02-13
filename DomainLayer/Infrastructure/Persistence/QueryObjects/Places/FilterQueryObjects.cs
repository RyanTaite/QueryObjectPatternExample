using DomainLayer.DataTransferObjects.Places;

namespace DomainLayer.Infrastructure.Persistence.QueryObjects.Places;

public static class FilterQueryObjects
{
    public static IQueryable<PlaceListDto> FilterPlaces(
        this IQueryable<PlaceListDto> query,
        PlacesFilter placesFilter)
    {
        return query
            .FilterOutInactive(placesFilter)
            .FilterOnName(placesFilter)
            .FilterOnState(placesFilter);
    }
    
    private static IQueryable<PlaceListDto> FilterOutInactive(this IQueryable<PlaceListDto> query, PlacesFilter placesFilter)
    {
        return placesFilter.IncludeInactive ? query : query.Where(place => place.IsActive);
    }

    private static IQueryable<PlaceListDto> FilterOnName(this IQueryable<PlaceListDto> query, PlacesFilter placesFilter)
    {
        return string.IsNullOrWhiteSpace(placesFilter.Name) ? query : query.Where(place => place.Name.Contains(placesFilter.Name));
    }
    
    private static IQueryable<PlaceListDto> FilterOnState(this IQueryable<PlaceListDto> query, PlacesFilter placesFilter)
    {
        return string.IsNullOrWhiteSpace(placesFilter.State) ? query : query.Where(place => place.State.Contains(placesFilter.State));
    }
}