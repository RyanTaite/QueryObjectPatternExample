using System.Linq.Expressions;
using DomainLayer.DataTransferObjects.Places;

namespace DomainLayer.Infrastructure.Persistence.QueryObjects.Places;

public static class SortQueryObjects
{
    public static IQueryable<PlaceListDto> SortPlaces(
        this IQueryable<PlaceListDto> query,
        PlacesSort placesSort)
    {
        var defaultSort = new PlacesSort
        {
            Sort = SortOrders.Descending
        };
        
        if (string.IsNullOrWhiteSpace(placesSort.ColumnToSort))
        {
            return query.SortOnName(defaultSort);
        }

        query = placesSort.ColumnToSort switch
        {
            nameof(PlaceListDto.Name) => SortOnName(query, placesSort),
            nameof(PlaceListDto.State) => SortOnState(query, placesSort),
            _ => SortOnName(query, defaultSort)
        };
        
        return query
            .SortOnName(placesSort)
            .SortOnState(placesSort);
    }

    private static IQueryable<PlaceListDto> SortOnName(this IQueryable<PlaceListDto> placeListDtos, PlacesSort placesSort)
    {
        Expression<Func<PlaceListDto, string>> name = placeListDto =>
            placeListDto.Name;

        return placesSort.Sort == SortOrders.Ascending
            ? placeListDtos.OrderBy(name)
            : placeListDtos.OrderByDescending(name);
    }
    
    private static IQueryable<PlaceListDto> SortOnState(this IQueryable<PlaceListDto> placeListDtos, PlacesSort placesSort)
    {
        Expression<Func<PlaceListDto, string>> state = placeListDto =>
            placeListDto.State;

        return placesSort.Sort == SortOrders.Ascending
            ? placeListDtos.OrderBy(state)
            : placeListDtos.OrderByDescending(state);
    }
}