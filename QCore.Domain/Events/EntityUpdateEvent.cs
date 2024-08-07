using QCore.Domain.Entities;

namespace QCore.Domain.Events;

public class EntityUpdateEvent<T> : IDomainEvent where T : Entity<Guid>
{

    public EntityUpdateEvent(T entity, DateTime enventDateTime)
    {
        Entity = entity;
        EventDateTime = enventDateTime;
    }

    public T Entity { get; set; }

    public DateTime EventDateTime { get; set; }
}