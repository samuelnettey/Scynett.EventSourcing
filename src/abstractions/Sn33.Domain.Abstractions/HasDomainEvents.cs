using System.ComponentModel.DataAnnotations.Schema;

namespace Sn33.Domain.Abstractions;

public abstract class HasDomainEvents
{
    private readonly List<DomainEvent> _domainEvents = new();
    [NotMapped]
    public IEnumerable<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void RegisterDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
        When(domainEvent);
    }

    internal void ClearDomainEvents() => _domainEvents.Clear();

    protected abstract void When(DomainEvent domainEvent);
}
