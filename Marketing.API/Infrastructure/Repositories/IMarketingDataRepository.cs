using Marketing.API.Model;
using System.Threading.Tasks;

namespace Marketing.API.Infrastructure.Repositories
{

    public interface IMarketingDataRepository
    {
        Task<MarketingData> GetAsync(string userId);
        Task UpdateLocationAsync(MarketingData marketingData);
    }
}
