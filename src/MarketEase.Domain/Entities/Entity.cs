using Flunt.Notifications;

namespace MarketEase.Domain.Entities;

public abstract class Entity : Notifiable<Notification>
{
    public Guid Id { get; private set; }
    
    public Entity()
    {   
        Id = Guid.NewGuid();
    }
}