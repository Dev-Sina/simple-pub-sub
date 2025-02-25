using PubSub.Application.Events;
using PubSub.Domain.Entities;
using System.Collections.Concurrent;

namespace PubSub.Application.Services;

public class OrderService
{
    private readonly EventBus _eventBus;
    private readonly ConcurrentBag<Order> _orders;

    public OrderService(EventBus eventBus)
    {
        _eventBus = eventBus;
        _orders =
            [
                new Order(1, 350000M, DateTime.UtcNow.AddDays(-3)),
                new Order(2, 186000M, DateTime.UtcNow.AddDays(-2)),
                new Order(3, 1030000M, DateTime.UtcNow.AddDays(-1))
            ];
    }

    public async Task PayOrderAsync(uint id, CancellationToken ct = default)
    {
        var order = _orders.First(o => o.Id == id);
        await _eventBus.PublishAsync(new OrderPaidEvent(order.Id));
        await Task.CompletedTask;
    }
}
