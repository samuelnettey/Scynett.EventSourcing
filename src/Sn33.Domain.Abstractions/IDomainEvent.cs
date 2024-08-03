using System;

using MediatR;

namespace Sn33.Domain.Abstractions
{
    /// <summary>
    /// Represents a domain event within the domain model.
    /// Domain events capture occurrences within the domain that domain experts care about.
    /// </summary>
    public interface IDomainEvent : INotification { }

    /// <summary>
    /// Provides a base implementation for domain events.
    /// This abstract class implements the IDomainEvent interface and includes a timestamp for when the event occurred.
    /// </summary>
    public abstract class DomainEvent : IDomainEvent
    {
        /// <summary>
        /// Gets the date and time when the domain event occurred.
        /// This value is set to the current UTC date and time when the event is created.
        /// </summary>
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
