using CadetTest.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadetTest.Services.Abstract
{

    public interface IConsentService
    {
        Task<Consent> GetConsentByIdAsync(int id);
        Task<IEnumerable<Consent>> GetAllConsentsAsync();
        Task AddConsentAsync(Consent consent);
        Task UpdateConsentAsync(Consent consent);
        Task RemoveConsentAsync(int id);
    }

}
