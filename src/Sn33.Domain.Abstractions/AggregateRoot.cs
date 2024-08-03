using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sn33.Domain.Abstractions
{
    /// <summary>
    /// Represents the base class for aggregate roots in the domain model.
    /// An aggregate root is the entry point for accessing an aggregate and ensures consistency and encapsulation of the aggregate's state.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier for the aggregate root.</typeparam>
    public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot where TId : struct, IEquatable<TId>
    {
        /// <summary>
        /// A list of uncommitted domain events that have occurred within the aggregate but have not yet been persisted or dispatched.
        /// </summary>
        private readonly List<DomainEvent> _uncommittedEvents = new();

        /// <summary>
        /// Gets or sets the unique identifier for the aggregate.
        /// </summary>
        public Guid AggregateId { get; protected set; }

        /// <summary>
        /// Gets or sets the version of the aggregate.
        /// This is used for concurrency control to ensure that changes are applied to the correct version of the aggregate.
        /// </summary>
        public long Version { get; set; }

        /// <summary>
        /// Gets the collection of uncommitted domain events.
        /// Uncommitted events are those that have been raised but not yet persisted or dispatched.
        /// </summary>
        /// <returns>A read-only collection of uncommitted domain events.</returns>
        public IEnumerable<DomainEvent> GetUncommittedEvents() => _uncommittedEvents.AsReadOnly();

        /// <summary>
        /// Clears all uncommitted events from the aggregate.
        /// This is typically called after the events have been persisted or dispatched.
        /// </summary>
        public void ClearUncommittedEvents() => _uncommittedEvents.Clear();

        /// <summary>
        /// Applies a domain event to the aggregate.
        /// This method registers the event and adds it to the list of uncommitted events.
        /// </summary>
        /// <param name="event">The domain event to apply.</param>
        public void Apply(DomainEvent @event)
        {
            RegisterDomainEvent(@event);
            _uncommittedEvents.Add(@event);
        }
    }
}
