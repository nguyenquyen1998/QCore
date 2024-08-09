using QCore.Domain.Entities;

namespace QCore.Domain.Events;

public class EntityDeletedEvent<T> : IDomainEvent where T : Entity<Guid>
{

    public EntityDeletedEvent(T entity, DateTime enventDateTime)
    {
        Entity = entity;
        EventDateTime = enventDateTime;
    }

    public T Entity { get; set; }

    public DateTime EventDateTime { get; set; }
}