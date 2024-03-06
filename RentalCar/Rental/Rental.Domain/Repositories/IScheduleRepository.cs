using Rental.Domain.Core.Interfaces;
using Rental.Domain.DomainModel.Entities;

namespace Rental.Domain.Repositories;
public interface IScheduleRepository: IRepository<DomainModel.Entities.CarRental>
{
}
