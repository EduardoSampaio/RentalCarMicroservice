using Rental.Domain.DomainModel.Entities;
using Rental.Domain.Repositories;
using Rental.Infrasctructure.EF;

namespace Rental.Infrasctructure.Repositories;
public class CarRentalRepository : Repository<CarRental>, ICarRentalRepository
{
    public CarRentalRepository(RentalContext context) : base(context) {}
}
