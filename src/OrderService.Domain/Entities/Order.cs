using OrderService.Domain.Enums;

namespace OrderService.Domain.Entities;

public class Order
{
    private readonly List<OrderItem> _items = new();

    public Guid Id { get; }
    public OrderStatus Status { get; private set; }
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
    public decimal Total => _items.Sum(i => i.Total);

    public Order()
    {
        Id = Guid.NewGuid();
        Status = OrderStatus.Draft;
    }

    public void AddItem(OrderItem item)
    {
        EnsureIsDraft();
        _items.Add(item);
    }

    public void Confirm()
    {
        EnsureIsDraft();
        if (!_items.Any())
            throw new InvalidOperationException("Cannot confirm an order without items.");

        Status = OrderStatus.Confirmed;
    }

    public void Cancel()
    {
        if (Status == OrderStatus.Canceled)
            return;

        Status = OrderStatus.Canceled;
    }

    private void EnsureIsDraft()
    {
        if (Status != OrderStatus.Draft)
            throw new InvalidOperationException("Only draft orders can be modified.");
    }
}