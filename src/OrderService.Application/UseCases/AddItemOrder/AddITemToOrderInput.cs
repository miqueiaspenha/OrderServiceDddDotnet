namespace OrderService.Application.UseCases.AddItemToOrder;

public record AddItemToOrderInput(
    Guid OrderId,
    Guid ProductId,
    string ProductName,
    int Quantity,
    decimal UnitPrice
);