using OrderService.Application.Interfaces;
using OrderService.Domain.Entities;

namespace OrderService.Application.UseCases.AddItemToOrder;

public class AddItemToOrderUseCase
{
    private readonly IOrderRepository _orderRepository;


    public AddItemToOrderUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<AdditemToOrderOutput> ExecuteAsync(AddItemToOrderInput input)
    {
        var order = await _orderRepository.GetOrderAsync(input.OrderId);

        if (order is null)
            throw new InvalidOperationException("Order not found.");

        var item = new OrderItem(
            input.ProductId,
            input.ProductName,
            input.Quantity,
            input.UnitPrice
        );

        order.AddItem(item);

        await _orderRepository.UpdateAsync(order);

        return new AdditemToOrderOutput(order.Id, order.Total);
    }
}