namespace PubSub.Domain.Entities;

public class Order : BaseEntity<uint>
{
    public decimal TotalPrice { get; }
    public DateTime CreatedOn { get; }

    public Order(uint id, decimal totalPrice, DateTime createdOn) : base(id)
    {
        TotalPrice = totalPrice;
        CreatedOn = createdOn;
    }
}
