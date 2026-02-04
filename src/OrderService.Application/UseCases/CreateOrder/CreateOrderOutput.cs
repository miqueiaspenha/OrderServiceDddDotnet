using OrderService.Domain.Enums;

namespace OrderService.Application.UseCases.CreateOrder;

public record CreateOrderOutput(Guid OrderId, OrderStatus Status);