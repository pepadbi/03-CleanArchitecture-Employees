using System.Reflection;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.ContributorAggregate;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infrastructure.Data;

public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher? _dispatcher;

  public AppDbContext(DbContextOptions<AppDbContext> options,
      IDomainEventDispatcher? dispatcher)
      : base(options)
  {
    _dispatcher = dispatcher;
  }

  // Přidáno DbSet pro Employee
  public DbSet<Employee> Employees => Set<Employee>();
  public DbSet<Contributor> Contributors => Set<Contributor>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    // Zde můžeme přidat konfiguraci pro model Employee, pokud je potřeba
    modelBuilder.Entity<Employee>(entity =>
    {
      entity.ToTable("Employees");

      // Příklad konfigurace vlastností:
      entity.HasKey(e => e.Id);
      entity.Property(e => e.FirstName).IsRequired();
      entity.Property(e => e.LastName).IsRequired();
    });
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Any())
        .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges() =>
      SaveChangesAsync().GetAwaiter().GetResult();
}
