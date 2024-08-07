using QCore.Domain.Entities;

namespace QCore.Domain.Events;

public class EntityCreatedEvent<T> : IDomainEvent where T : Entity<Guid>
{

    public EntityCreatedEvent(T entity, DateTime enventDateTime)
    {
        Entity = entity;
        EventDateTime = enventDateTime;
    }

    public T Entity { get; set; }

    public DateTime EventDateTime { get; set; }
}