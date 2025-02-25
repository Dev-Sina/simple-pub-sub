using PubSub.Application.Events;
using PubSub.Application.Interfaces;

namespace PubSub.Infrastructure.Subscribers.OrderPaidEventHandlers;

public class ChangePaymentStatusOrderPaidEventHandler : IEventHandler<OrderPaidEvent>
{
    public async Task HandleAsync(OrderPaidEvent @event)
    {
        Console.WriteLine($"Set the payment status as paid for the order with id of: {@event.OrderId}");
        await Task.CompletedTask;
    }
}
