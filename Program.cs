using PubSub.Application.Events;
using PubSub.Application.Services;
using PubSub.Domain.Entities;

var eventBus = new EventBus();
eventBus.AutoRegisterSubscribers();

var order1 = new Order(1L, 350000M, DateTime.UtcNow.AddDays(-3));
var order2 = new Order(2L, 186000M, DateTime.UtcNow.AddDays(-2));
var order3 = new Order(3L, 1030000M, DateTime.UtcNow.AddDays(-1));
var orderPaidEvent1 = new OrderPaidEvent(order1.Id);
var orderPaidEvent2 = new OrderPaidEvent(order2.Id);
var orderPaidEvent3 = new OrderPaidEvent(order3.Id);
await eventBus.PublishAsync(orderPaidEvent1);
await eventBus.PublishAsync(orderPaidEvent2);
await eventBus.PublishAsync(orderPaidEvent3);

var shipment1 = new Shipment(1L, 1L, "1000100067843");
var shipment2 = new Shipment(2L, 1L, "2000100099152");
var shipment3 = new Shipment(3L, 2L, "3000200068853");
var shipmentSentEvent1 = new ShipmentSentEvent(shipment1.Barcode!);
var shipmentSentEvent2 = new ShipmentSentEvent(shipment2.Barcode!);
var shipmentSentEvent3 = new ShipmentSentEvent(shipment3.Barcode!);
await eventBus.PublishAsync(shipmentSentEvent1);
await eventBus.PublishAsync(shipmentSentEvent2);
await eventBus.PublishAsync(shipmentSentEvent3);
