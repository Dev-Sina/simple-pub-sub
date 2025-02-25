using PubSub.Application.Events;
using PubSub.Application.Interfaces;

namespace PubSub.Infrastructure.Subscribers.ShipmentSentEventHandlers;

public class SendSmsShipmentSentEventHandler : IEventHandler<ShipmentSentEvent>
{
    public async Task HandleAsync(ShipmentSentEvent @event)
    {
        Console.WriteLine($"Sending a sms to notify that the order with barcode of: {@event.Barcode} is paid");
        await Task.CompletedTask;
    }
}
