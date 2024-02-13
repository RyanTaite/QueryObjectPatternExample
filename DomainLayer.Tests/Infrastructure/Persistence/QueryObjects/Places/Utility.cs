using DomainLayer.DataTransferObjects.Places;

namespace DomainLayer.Tests.Infrastructure.Persistence.QueryObjects.Places;

public static class Utility
{
    internal static PlacesFilter GetDefaultPlacesFilter()
    {
        var placesFilter = new PlacesFilter
        {
            Name = string.Empty,
            State = string.Empty,
            IncludeInactive = false
        };

        return placesFilter;
    }

    internal static PlacesSort GetDefaultPlaceSort()
    {
        var placesSort = new PlacesSort
        {
            Sort = string.Empty,
            ColumnToSort = string.Empty
        };

        return placesSort;
    }
}