using System.Threading.Tasks;
using System.Threading;
using System;

namespace CadetTest.Infrastructure.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        int SaveChanges();

    }
}
