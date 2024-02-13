using DomainLayer.DataTransferObjects.Places;
using DomainLayer.Infrastructure.Persistence.QueryObjects.Places;
using System.Text.Json;
using ServiceLayer.Place;

namespace ServiceLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var pretendPlacesContext = new List<DomainLayer.Entities.Places.Place>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    ModifiedDate = DateTime.Now,
                    Name = "First",
                    State = "AZ"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    ModifiedDate = DateTime.Now,
                    Name = "First - Two",
                    State = "AZ"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    ModifiedDate = DateTime.Now,
                    Name = "Second",
                    State = "NM"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = false,
                    ModifiedDate = DateTime.Now,
                    Name = "Second - Two",
                    State = "CA"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = false,
                    ModifiedDate = DateTime.Now,
                    Name = "Forth",
                    State = "NC"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    ModifiedDate = DateTime.Now,
                    Name = "Fifth",
                    State = "SC"
                }
            };
            
            PlaceService placeService = new(pretendPlacesContext);
            var placesFilter = new PlacesFilter
            {
                IncludeInactive = false,
                //Name = "First",
                //State = "AZ"
            };

            var placesSort = new PlacesSort
            {
                ColumnToSort = nameof(PlaceListDto.State),
                Sort = SortOrders.Descending
            };

            var result = placeService.GetPlaceListDtos(placesFilter, placesSort);

            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
            };
            foreach (var resultDto in result)
            {
                Console.WriteLine(JsonSerializer.Serialize(resultDto, options));
            }
        }
    }
}