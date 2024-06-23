using CadetTest.Infrastructure.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Security.Principal;

namespace CadetTest.Infrastructure.Concrete
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
	where TEntity : class
	where TContext : DbContext
	{

		protected readonly TContext _context;
		private DbSet<TEntity> Entity;

		public Repository(TContext context)
		{
			_context = context;
			Entity = _context.Set<TEntity>();

		}

		



		public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
		{
			return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
		}

		public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
		{
			return filter == null
				? await _context.Set<TEntity>().ToListAsync()
				: await _context.Set<TEntity>().Where(filter).ToListAsync();
		}

		public async Task AddAsync(TEntity entity)
		{
			await _context.Set<TEntity>().AddAsync(entity);
		}
		

		public async Task DeleteAsync(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
		}

		public async Task UpdateAsync(TEntity entity)
		{
			  _context.Entry(entity).State = EntityState.Modified;
		}

	}
}
