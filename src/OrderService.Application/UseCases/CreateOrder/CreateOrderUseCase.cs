using OrderService.Application.Interfaces;
using OrderService.Domain.Entities;

namespace OrderService.Application.UseCases.CreateOrder;

public class CreateOrderUseCase
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<CreateOrderOutput> ExecuteAsync()
    {
        var order = new Order();
        await _orderRepository.AddAsync(order);
        return new CreateOrderOutput(order.Id, order.Status);
    }
}