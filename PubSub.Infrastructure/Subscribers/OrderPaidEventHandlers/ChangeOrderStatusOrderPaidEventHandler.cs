using PubSub.Application.Events;
using PubSub.Application.Interfaces;

namespace PubSub.Infrastructure.Subscribers.OrderPaidEventHandlers;

public class ChangeOrderStatusOrderPaidEventHandler : IEventHandler<OrderPaidEvent>
{
    public async Task HandleAsync(OrderPaidEvent @event)
    {
        Console.WriteLine($"Set the order status as preparing for the order with id of: {@event.OrderId}");
        await Task.CompletedTask;
    }
}
