using Locations.API.Model;
using Locations.API.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Locations.API.Infrastructure.Repositories
{

    public interface ILocationsRepository
    {        
        Task<Location> GetAsync(int locationId);

        Task<List<Location>> GetLocationListAsync();

        Task<UserLocation> GetUserLocationAsync(string userId);

        Task<List<Location>> GetCurrentUserRegionsListAsync(LocationRequest currentPosition);

        Task AddUserLocationAsync(UserLocation location);

        Task UpdateUserLocationAsync(UserLocation userLocation);

    }
}
