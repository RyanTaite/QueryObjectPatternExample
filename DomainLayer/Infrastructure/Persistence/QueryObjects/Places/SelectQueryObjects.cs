using DomainLayer.DataTransferObjects.Places;
using DomainLayer.Entities.Places;

namespace DomainLayer.Infrastructure.Persistence.QueryObjects.Places;

public static class SelectQueryObjects
{
    public static IQueryable<PlaceListDto> SelectPlacesForList(this IQueryable<Place> places)
    {
        return places
            .Select(place => new PlaceListDto
            {
                Id = place.Id,
                Name = place.Name,
                State = place.State,
                IsActive = place.IsActive
            });
    }
}