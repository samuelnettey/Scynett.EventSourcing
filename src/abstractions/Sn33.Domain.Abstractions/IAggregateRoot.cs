namespace Sn33.Domain.Abstractions
{
    /// <summary>
    /// Represents an aggregate root in the domain model.
    /// Aggregate roots are the entry points for accessing the aggregate, ensuring consistency and encapsulation.
    /// </summary>
    public interface IAggregateRoot
    {
        /// <summary>
        /// Gets the unique identifier for the aggregate.
        /// </summary>
        Guid AggregateId { get; }

        /// <summary>
        /// Gets or sets the version of the aggregate.
        /// This is used for concurrency control to ensure that changes are applied to the correct version of the aggregate.
        /// </summary>
        long Version { get; set; }

        /// <summary>
        /// Applies a domain event to the aggregate.
        /// This method is used to apply events that have been raised within the aggregate,
        /// updating its state accordingly.
        /// </summary>
        /// <param name="event">The domain event to apply.</param>
        void Apply(DomainEvent @event);

        /// <summary>
        /// Clears all uncommitted events from the aggregate.
        /// This is typically called after the events have been persisted or dispatched.
        /// </summary>
        void ClearUncommittedEvents();

        /// <summary>
        /// Gets the collection of uncommitted domain events.
        /// Uncommitted events are those that have been raised but not yet persisted or dispatched.
        /// </summary>
        /// <returns>A collection of uncommitted domain events.</returns>
        IEnumerable<DomainEvent> GetUncommittedEvents();
    }
}
