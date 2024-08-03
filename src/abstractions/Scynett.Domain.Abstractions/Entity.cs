namespace Scynett.Domain.Abstractions;

public abstract class Entity<TId> : HasDomainEventsBase where TId : struct, IEquatable<TId>
{
    public TId Id { get; set; }
}
