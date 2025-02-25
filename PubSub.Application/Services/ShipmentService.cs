using PubSub.Application.Events;
using PubSub.Domain.Entities;
using System.Collections.Concurrent;

namespace PubSub.Application.Services;

public class ShipmentService
{
    private readonly EventBus _eventBus;
    private readonly ConcurrentBag<Shipment> _shipments;

    public ShipmentService(EventBus eventBus)
    {
        _eventBus = eventBus;
        _shipments =
            [
                new Shipment(1L, 1, "1000100067843"),
                new Shipment(2L, 1, "2000100099152"),
                new Shipment(3L, 2, "3000200068853")
            ];
    }

    public async Task SendShipmentAsync(ulong id, CancellationToken ct = default)
    {
        var shipment = _shipments.First(s => s.Id == id);
        await _eventBus.PublishAsync(new ShipmentSentEvent(shipment.Barcode));
        await Task.CompletedTask;
    }
}
