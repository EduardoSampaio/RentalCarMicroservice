using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental.Domain.DomainModel.Entities;

namespace Rental.Infrasctructure.Mappings;
public class CarCatalogMapping : IEntityTypeConfiguration<CarCatalog>
{
    public void Configure(EntityTypeBuilder<CarCatalog> builder)
    {
        throw new NotImplementedException();
    }
}
