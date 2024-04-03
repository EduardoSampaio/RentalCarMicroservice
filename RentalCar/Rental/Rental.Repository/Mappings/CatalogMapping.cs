using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental.Domain.DomainModel.Entities;

namespace Rental.Infrasctructure.Mappings;
public class CatalogMapping : IEntityTypeConfiguration<Catalog>
{
    public void Configure(EntityTypeBuilder<Catalog> builder)
    {
        throw new NotImplementedException();
    }
}
