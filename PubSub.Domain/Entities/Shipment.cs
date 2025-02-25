namespace PubSub.Domain.Entities;

public class Shipment : BaseEntity<ulong>
{
    public uint OrderId { get; }
    public string Barcode { get; } = null!;

    public Shipment(ulong id, uint orderId, string barcode) : base(id)
    {
        OrderId = orderId;
        Barcode = barcode;
    }
}
