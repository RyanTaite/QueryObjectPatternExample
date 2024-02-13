using DomainLayer.DataTransferObjects.Places;

namespace ServiceLayer.Place;

public interface IPlaceService
{
    List<PlaceListDto> GetPlaceListDtos(PlacesFilter placesFilter, PlacesSort placesSort);
}