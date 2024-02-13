using DomainLayer.DataTransferObjects.Places;
using DomainLayer.Infrastructure.Persistence.QueryObjects.Places;

namespace DomainLayer.Tests.Infrastructure.Persistence.QueryObjects.Places;

public class SortQueryObjectTests
{
    [Fact]
    public void SortPlaceListDtos_NoSortGiven_SortsOnNameInDescOrder()
    {
        // Arrange
        var placeListDtos = new List<PlaceListDto>
        {
            new()
            {
                Name = "A"
            },
            new()
            {
                Name = "B"
            }
        };

        var expected = placeListDtos
            .Select(placeListDto => placeListDto.Name)
            .OrderByDescending(name => name)
            .ToList();

        var defaultPlaceSort = Utility.GetDefaultPlaceSort();

        // Act
        var result = placeListDtos
            .AsQueryable()
            .SortPlaces(defaultPlaceSort)
            .ToList();

        // Assert
        result.Select(placeListDto => placeListDto.Name)
            .Should()
            .NotBeEmpty()
            .And
            .Equal(expected);
    }

    [Theory]
    [InlineData(SortOrders.Ascending)]
    [InlineData(SortOrders.Descending)]
    public void SortPlaceListDtos_SortOnName_SortsInGivenOrder(string sortOrder)
    {
        // Arrange
        var placeListDtos = new List<PlaceListDto>
        {
            new()
            {
                Name = "A"
            },
            new()
            {
                Name = "B"
            }
        };

        var defaultPlaceSort = Utility.GetDefaultPlaceSort();
        defaultPlaceSort.ColumnToSort = nameof(PlaceListDto.Name);
        defaultPlaceSort.Sort = sortOrder;
        
        var sorted = sortOrder == SortOrders.Ascending
            ? placeListDtos.OrderBy(item => item.Name)
            : placeListDtos.OrderByDescending(item => item.Name);
        
        var expected = sorted
            .Select(x => x.Name)
            .ToList();

        // Act
        var result = placeListDtos
            .AsQueryable()
            .SortPlaces(defaultPlaceSort)
            .ToList();

        // Assert
        result.Select(placeListDto => placeListDto.Name)
            .Should()
            .NotBeEmpty()
            .And
            .Equal(expected);
    }
    
    [Theory]
    [InlineData(SortOrders.Ascending)]
    [InlineData(SortOrders.Descending)]
    public void SortPlaceListDtos_SortOnState_SortsInGivenOrder(string sortOrder)
    {
        // Arrange
        var placeListDtos = new List<PlaceListDto>
        {
            new()
            {
                State = "A"
            },
            new()
            {
                State = "B"
            }
        };

        var defaultPlaceSort = Utility.GetDefaultPlaceSort();
        defaultPlaceSort.ColumnToSort = nameof(PlaceListDto.State);
        defaultPlaceSort.Sort = sortOrder;
        
        var sorted = sortOrder == SortOrders.Ascending
            ? placeListDtos.OrderBy(item => item.State)
            : placeListDtos.OrderByDescending(item => item.State);
        
        var expected = sorted
            .Select(x => x.State)
            .ToList();

        // Act
        var result = placeListDtos
            .AsQueryable()
            .SortPlaces(defaultPlaceSort)
            .ToList();

        // Assert
        result.Select(placeListDto => placeListDto.State)
            .Should()
            .NotBeEmpty()
            .And
            .Equal(expected);
    }
}