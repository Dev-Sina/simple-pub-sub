using PubSub.Application.Events;
using PubSub.Application.Services;
using PubSub.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<EventBus>();
services.AddSingleton<OrderService>();
services.AddSingleton<ShipmentService>();

var serviceProvider = services.BuildServiceProvider();

var orderService = serviceProvider.GetRequiredService<OrderService>();
var shipmentService = serviceProvider.GetRequiredService<ShipmentService>();

await orderService.PayOrderAsync(1);
await orderService.PayOrderAsync(2);
await orderService.PayOrderAsync(3);
await shipmentService.SendShipmentAsync(1L);
await shipmentService.SendShipmentAsync(2L);
await shipmentService.SendShipmentAsync(3L);
