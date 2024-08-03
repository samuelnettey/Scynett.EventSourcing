using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sn33.Domain.Abstractions
{
    /// <summary>
    /// Represents a base class that provides domain event management capabilities.
    /// Entities and aggregate roots inheriting from this class can register and manage domain events.
    /// </summary>
    public abstract class HasDomainEvents
    {
        /// <summary>
        /// A list of domain events that have been raised within the entity or aggregate root.
        /// </summary>
        private readonly List<DomainEvent> _domainEvents = new();

        /// <summary>
        /// Gets the collection of domain events that have been raised but not yet persisted or dispatched.
        /// </summary>
        public IEnumerable<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        /// <summary>
        /// Registers a domain event and calls the When method to handle the event.
        /// </summary>
        /// <param name="domainEvent">The domain event to register.</param>
        protected void RegisterDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
            When(domainEvent);
        }

        /// <summary>
        /// Clears all domain events from the entity or aggregate root.
        /// This is typically called after the events have been persisted or dispatched.
        /// </summary>
        internal void ClearDomainEvents() => _domainEvents.Clear();

        /// <summary>
        /// Handles the domain event. Derived classes must implement this method to define
        /// how the domain events should be processed.
        /// </summary>
        /// <param name="domainEvent">The domain event to handle.</param>
        protected abstract void When(DomainEvent domainEvent);
    }
}
