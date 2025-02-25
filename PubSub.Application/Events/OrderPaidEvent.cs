namespace PubSub.Application.Events;

public class OrderPaidEvent : IEvent
{
    public long OrderId { get; }

    private OrderPaidEvent()
    {
    }

    public OrderPaidEvent(long orderId)
    {
        OrderId = orderId;
    }
}
