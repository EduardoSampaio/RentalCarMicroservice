using Microsoft.EntityFrameworkCore;
using Rental.Domain.Core;
using Rental.Domain.Core.Interfaces;
using Rental.Domain.DomainModel.Entities;

namespace Rental.Infrasctructure.EF;
public class RentalContext : DbContext, IUnitOfWork
{
    public RentalContext(DbContextOptions<RentalContext> options) : base(options) { }

    private DbSet<Catalog> Catalog { get; set; }
    private DbSet<Category> Category { get; set; }
    private DbSet<CarRental> CarRental { get; set; }
    private DbSet<Client> Client { get; set; }

    public async Task<bool> Commit()
    {
        foreach (var entry in base.ChangeTracker.Entries<Entity>().Where(q => q.State == EntityState.Added
        || q.State == EntityState.Modified))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.Now;
            }
        }

        return await base.SaveChangesAsync() > 0;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
