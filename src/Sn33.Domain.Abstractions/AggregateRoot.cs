using System.Text.Json.Serialization;

namespace Sn33.Domain.Abstractions;

public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot where TId : struct, IEquatable<TId>
{
    private readonly List<DomainEvent> _uncommittedEvents = new();

    public Guid AggregateId { get; protected set; }
    public long Version { get; set; }

    public IEnumerable<DomainEvent> GetUncommittedEvents() => _uncommittedEvents.AsReadOnly();

    public void ClearUncommittedEvents() => _uncommittedEvents.Clear();

    public void Apply(DomainEvent @event)
    {
        RegisterDomainEvent(@event);
        _uncommittedEvents.Add(@event);
    }
}