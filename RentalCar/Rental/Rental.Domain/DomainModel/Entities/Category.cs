using Rental.Domain.Core;

namespace Rental.Domain.DomainModel.Entities;
public class Category : Entity
{
    public decimal TotalPerDay { get; set; }
    public string Name { get; set; }
    public string? Commentary { get; set; }

    public Category(decimal totalPerDay, string name, string? commentary)
    {
        TotalPerDay = totalPerDay;
        Name = name;
        Commentary = commentary;
    }

    public Category(decimal totalPerDay, string name)
    {
        TotalPerDay = totalPerDay;
        Name = name;
    }
}
