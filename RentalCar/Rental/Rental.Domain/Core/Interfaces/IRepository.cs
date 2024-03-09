using System.Linq.Expressions;

namespace Rental.Domain.Core.Interfaces;
public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    IUnitOfWork UnitOfWork { get; }
    Task CreateAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");
    Task<TEntity?> GetByIdAsync(int id);   
}
