using Microsoft.EntityFrameworkCore;
using Rental.Domain.Core;
using Rental.Domain.Core.Interfaces;
using Rental.Infrasctructure.EF;
using System.Linq.Expressions;
using System.Data;


namespace Rental.Infrasctructure.Repositories;
public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    internal RentalContext _context;
    internal DbSet<TEntity> dbSet;

    public Repository(RentalContext context)
    {
        _context = context;
        dbSet = context.Set<TEntity>();
    }
    public IUnitOfWork UnitOfWork => _context;

    public virtual async Task CreateAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
    }

    public virtual void Update(TEntity entity)
    {
        dbSet.Entry(entity).State = EntityState.Modified;
    }

    public virtual void Delete(TEntity entity)
    {
        dbSet.Remove(entity);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
           return await orderBy(query).AsNoTracking().ToListAsync();

        }
        else
        {
            return await query.AsNoTracking().ToListAsync();
        }
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public virtual void Dispose()
    {
        _context?.Dispose();
    }
}
