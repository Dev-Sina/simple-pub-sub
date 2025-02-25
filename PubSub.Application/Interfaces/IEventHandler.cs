using PubSub.Application.Events;

namespace PubSub.Application.Interfaces;

public interface IEventHandler<T> where T : IEvent
{
    Task HandleAsync(T @event);
}