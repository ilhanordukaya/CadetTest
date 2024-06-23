using CadetTest.Entities;
using CadetTest.Infrastructure.Abstract;
using CadetTest.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadetTest.Services.Concrete
{
    public class ConsentService : IConsentService
    {
        private readonly IConsentRepository _consentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ConsentService(IConsentRepository consentRepository, IUnitOfWork unitOfWork)
        {
            _consentRepository = consentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Consent> GetConsentByIdAsync(int id)
        {
            return await _consentRepository.GetAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Consent>> GetAllConsentsAsync()
        {
            return await _consentRepository.GetListAsync();
        }

        public async Task AddConsentAsync(Consent consent)
        {
            await _consentRepository.AddAsync(consent);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateConsentAsync(Consent consent)
        {
            await _consentRepository.UpdateAsync(consent);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveConsentAsync(int id)
        {
            var consent = await _consentRepository.GetAsync(c => c.Id == id);
            if (consent != null)
            {
                await _consentRepository.DeleteAsync(consent);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
