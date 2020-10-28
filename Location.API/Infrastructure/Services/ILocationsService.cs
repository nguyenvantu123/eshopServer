using Locations.API.Model;
using Locations.API.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Locations.API.Infrastructure.Services
{

    public interface ILocationsService
    {
        Task<Location> GetLocationAsync(int locationId);

        Task<UserLocation> GetUserLocationAsync(string id);

        Task<List<Location>> GetAllLocationAsync();

        Task<bool> AddOrUpdateUserLocationAsync(string userId, LocationRequest locRequest);
    }
}
