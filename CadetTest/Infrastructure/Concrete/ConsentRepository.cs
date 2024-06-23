using CadetTest.Entities;
using CadetTest.Helpers;
using CadetTest.Infrastructure.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CadetTest.Infrastructure.Concrete
{
    public class ConsentRepository : Repository<Consent, DataContext>, IConsentRepository
    {
        public ConsentRepository(DataContext context) : base(context)
        {
        }
    }
}
