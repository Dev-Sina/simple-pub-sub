using PubSub.Application.Events;
using PubSub.Application.Interfaces;

namespace PubSub.Infrastructure.Subscribers.ShipmentSentEventHandlers;

public class ChangeShipmentStatusShipmentSentEventHandler : IEventHandler<ShipmentSentEvent>
{
    public async Task HandleAsync(ShipmentSentEvent @event)
    {
        Console.WriteLine($"Set the shipment status as sent for the shipment with barcode of: {@event.Barcode}");
        await Task.CompletedTask;
    }
}
