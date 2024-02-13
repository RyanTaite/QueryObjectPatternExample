using DomainLayer.DataTransferObjects.Places;
using DomainLayer.Infrastructure.Persistence.QueryObjects.Places;

namespace DomainLayer.Tests.Infrastructure.Persistence.QueryObjects.Places;

public class FilterQueryObjectTests
{
    [Theory]
    [InlineData(false, 1)]
    [InlineData(true, 2)]
    public void FilterPlaceListDtos_FilterIncludesInactive_ReturnsCorrectCount(
        bool shouldIncludeInactive,
        int expectedCount)
    {
        // Arrange
        var placeListDtos = new List<PlaceListDto>
        {
            new()
            {
                IsActive = true
            },
            new()
            {
                IsActive = false
            }
        };

        var defaultPlacesFilter = Utility.GetDefaultPlacesFilter();
        defaultPlacesFilter.IncludeInactive = shouldIncludeInactive;

        // Act
        var result = placeListDtos
            .AsQueryable()
            .FilterPlaces(defaultPlacesFilter)
            .ToList();

        // Assert
        result.Should()
            .NotBeEmpty()
            .And
            .HaveCount(expectedCount);
    }

    [Theory]
    [InlineData("First")]
    [InlineData("Second")]
    public void FilterPlaceListDtos_FiltersOnName_ReturnsMatchingItems(string expectedName)
    {
        // Arrange
        var placeListDtos = new List<PlaceListDto>
        {
            new()
            {
                Name = "First",
                IsActive = true
            },
            new()
            {
                Name = "FirstPerson",
                IsActive = true
            },
            new()
            {
                Name = "Second",
                IsActive = true
            }
        };

        var defaultPlacesFilter = Utility.GetDefaultPlacesFilter();
        defaultPlacesFilter.Name = expectedName;

        // Act
        var result = placeListDtos
            .AsQueryable()
            .FilterPlaces(defaultPlacesFilter)
            .ToList();

        // Assert
        result.Should()
            .NotBeEmpty()
            .And
            .OnlyContain(placeListDto => placeListDto.Name.Contains(expectedName));
    }

    [Theory]
    [InlineData("AZ")]
    [InlineData("NM")]
    public void FilterPlaceListDtos_FiltersOnState_ReturnsMatchingItems(string expectedState)
    {
        // Arrange
        var placeListDtos = new List<PlaceListDto>
        {
            new()
            {
                State = "AZ",
                IsActive = true
            },
            new()
            {
                State = "NM",
                IsActive = true
            }
        };

        var defaultPlacesFilter = Utility.GetDefaultPlacesFilter();
        defaultPlacesFilter.State = expectedState;

        // Act
        var result = placeListDtos
            .AsQueryable()
            .FilterPlaces(defaultPlacesFilter)
            .ToList();

        // Assert
        result.Should()
            .NotBeEmpty()
            .And
            .OnlyContain(placeListDto => placeListDto.State == expectedState);
    }

    [Fact]
    public void FilterPlaceListDtos_NoFilter_ReturnsOnlyActiveItems()
    {
        // Arrange
        var placeListDtos = new List<PlaceListDto>
        {
            new()
            {
                IsActive = true
            },
            new()
            {
                IsActive = false
            }
        };

        var defaultPlacesFilter = Utility.GetDefaultPlacesFilter();

        // Act
        var result = placeListDtos
            .AsQueryable()
            .FilterPlaces(defaultPlacesFilter)
            .ToList();

        // Assert
        result.Should()
            .NotBeEmpty()
            .And
            .OnlyContain(placeListDto => placeListDto.IsActive);
    }
}