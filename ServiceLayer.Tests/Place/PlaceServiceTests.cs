using DomainLayer.DataTransferObjects.Places;
using DomainLayer.Infrastructure.Persistence.QueryObjects.Places;
using Moq.AutoMock;
using ServiceLayer.Place;

namespace ServiceLayer.Tests.Place;

public class PlaceServiceTests
{
    [Fact]
    public void GetPlaceListDtos_ShouldCallSelectPlacesForListOnce()
    {
        // Arrange
        var mocker = new AutoMocker();
        var placesFilter = new PlacesFilter();
        var placesSort = new PlacesSort();

        // Act
        var yourClassInstance = mocker.CreateInstance<PlaceService>();
        var result = yourClassInstance.GetPlaceListDtos(placesFilter, placesSort);

        // Assert
        mocker.GetMock<List<DomainLayer.Entities.Places.Place>>().Verify(c => c.AsQueryable(), Times.Once);
        mocker.GetMock<IQueryable<DomainLayer.Entities.Places.Place>>().Verify(q => q.SelectPlacesForList(), Times.Once);
        // Add any additional assertions for filtering, sorting, or the final result if needed
    }
}