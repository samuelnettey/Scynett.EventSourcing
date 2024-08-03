using MediatR;

namespace Scynett.Domain.Abstractions;

public interface IDomainEvent : INotification { }

public abstract class DomainEvent : IDomainEvent 
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
