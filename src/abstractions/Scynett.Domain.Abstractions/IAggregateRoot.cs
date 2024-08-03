namespace Scynett.Domain.Abstractions;

public interface IAggregateRoot 
{
    Guid AggregateId { get; }

    long Version { get; set; }

    void Apply(DomainEvent @event);

    void ClearUncommittedEvents();

    IEnumerable<DomainEvent> GetUncommittedEvents();
}
