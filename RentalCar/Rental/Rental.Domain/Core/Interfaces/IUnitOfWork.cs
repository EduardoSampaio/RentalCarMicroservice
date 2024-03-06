namespace Rental.Domain.Core.Interfaces;
public interface IUnitOfWork
{
    Task<bool> Commit();
}
