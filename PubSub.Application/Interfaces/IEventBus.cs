using PubSub.Application.Events;

namespace PubSub.Application.Interfaces;

public interface IEventBus
{
    Task PublishAsync<T>(T @event) where T : IEvent;
    void AutoRegisterSubscribers();
}
