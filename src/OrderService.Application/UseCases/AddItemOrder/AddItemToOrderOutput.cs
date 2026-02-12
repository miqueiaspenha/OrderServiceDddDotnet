namespace OrderService.Application.UseCases.AddItemToOrder;

public record AdditemToOrderOutput(
    Guid OrderId,
    decimal Total
);