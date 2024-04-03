using Rental.Domain.Core;

namespace Rental.Domain.DomainModel.Entities;
public class Category : Entity
{
    public decimal TotalPerDay { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Commentary { get; private set; }

    protected Category() {}

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

    public void UpdateCommentary(string commentary)
    {
        Commentary = commentary;
    }
}
