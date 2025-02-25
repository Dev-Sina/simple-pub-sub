using PubSub.Application.Events;
using PubSub.Application.Interfaces;

namespace PubSub.Infrastructure.Subscribers.OrderPaidEventHandlers;

public class SendSmsOrderPaidEventHandler : IEventHandler<OrderPaidEvent>
{
    public async Task HandleAsync(OrderPaidEvent @event)
    {
        Console.WriteLine($"Sending a sms to notify that the order with id of: {@event.OrderId} is paid");
        await Task.CompletedTask;
    }
}
