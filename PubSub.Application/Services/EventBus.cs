using PubSub.Application.Events;
using PubSub.Application.Interfaces;
using System.Reflection;

namespace PubSub.Application.Services;

public class EventBus : IEventBus
{
    private readonly Dictionary<Type, List<object>> _handlers = new();

    public async Task PublishAsync<T>(T @event) where T : IEvent
    {
        var eventType = typeof(T);
        if (_handlers.ContainsKey(eventType))
        {
            foreach (var handler in _handlers[eventType])
            {
                await ((IEventHandler<T>)handler).HandleAsync(@event);
            }
        }
    }

    public void AutoRegisterSubscribers()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

        string binPath = AppDomain.CurrentDomain.BaseDirectory;
        foreach (var dll in Directory.GetFiles(binPath, "*.dll"))
        {
            try
            {
                var assembly = Assembly.LoadFrom(dll);
                if (!assemblies.Contains(assembly))
                    assemblies.Add(assembly);
            }
            catch { }
        }

        var handlerTypes = assemblies.SelectMany(a => a.GetTypes())
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventHandler<>))
                && !t.IsAbstract && !t.IsInterface).DistinctBy(t => t.FullName);

        foreach (var type in handlerTypes)
        {
            var handlerInstance = Activator.CreateInstance(type);
            if (handlerInstance is null)
            {
                continue;
            }

            var handlerInterface = type.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IEventHandler<>));
            var eventType = handlerInterface.GetGenericArguments()[0];

            if (!_handlers.ContainsKey(eventType))
            {
                _handlers[eventType] = new List<object>();
            }
            _handlers[eventType].Add(handlerInstance);
        }
    }
}
