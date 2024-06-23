using CadetTest.Infrastructure.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using CadetTest.Helpers;

namespace CadetTest.Infrastructure.Concrete
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        protected DataContext _applicationContext;

        public UnitOfWork(DataContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _applicationContext.SaveChangesAsync(cancellationToken);
        }

        public int SaveChanges()
        {
            return _applicationContext.SaveChanges();
        }

        public void Dispose()
        {
            _applicationContext.Dispose();

        }
    }
}
