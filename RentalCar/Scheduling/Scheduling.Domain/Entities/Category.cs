using Scheduling.Domain.Core;

namespace Scheduling.Domain.Entities;
public class Category(decimal totalPerDay, string name) : Entity {

    public decimal TotalPerDay { get; set; } = totalPerDay;
    public string Name { get; set; } = name;
    public string? Commentary { get; set; }
}
