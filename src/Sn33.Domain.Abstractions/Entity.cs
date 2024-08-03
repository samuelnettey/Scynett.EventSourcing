namespace Sn33.Domain.Abstractions
{
    /// <summary>
    /// Represents a base class for all entities in the domain model.
    /// Entities are objects that have a distinct identity and are distinguished from other objects by their identity, not by their attributes.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier for the entity.</typeparam>
    public abstract class Entity<TId> : HasDomainEvents where TId : struct, IEquatable<TId>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        public TId Id { get; set; }
    }
}
