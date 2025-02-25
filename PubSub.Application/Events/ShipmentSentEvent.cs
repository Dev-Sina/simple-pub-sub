namespace PubSub.Application.Events;

public class ShipmentSentEvent : IEvent
{
    public string Barcode { get; } = null!;

    private ShipmentSentEvent()
    {
    }

    public ShipmentSentEvent(string barcode)
    {
        Barcode = barcode;
    }
}
