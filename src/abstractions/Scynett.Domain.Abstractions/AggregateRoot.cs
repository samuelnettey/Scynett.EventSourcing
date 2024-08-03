using System.Text.Json.Serialization;

namespace Scynett.Domain.Abstractions;

public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot where TId : struct, IEquatable<TId>
{
    [JsonIgnore]
    private readonly List<DomainEvent> _uncommittedEvents = new();


    public Guid AggregateId { get; protected set; }
    public long Version { get; set; }

    public IEnumerable<DomainEvent> GetUncommittedEvents() => _uncommittedEvents.AsReadOnly();

    public void ClearUncommittedEvents() => _uncommittedEvents.Clear();

    public void Apply(DomainEvent @event)
    {
        base.RegisterDomainEvent(@event);
        _uncommittedEvents.Add(@event);
    }
}