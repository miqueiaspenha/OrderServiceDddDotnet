namespace OrderService.Domain.Entities;

public class OrderItem
{
    public Guid ProductId { get; }
    public string ProductName { get; }
    public int Quantity { get; }
    public decimal UnitPrice { get; }

    public decimal Total => Quantity * UnitPrice;

    public OrderItem(Guid productId, string productName, int quantity, decimal unitPrice)
    {
        if (string.IsNullOrWhiteSpace(productName))
            throw new ArgumentException("Product name is required.");

        if (quantity < 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        if (unitPrice <= 0)
            throw new ArgumentException("Unit price must be greater than zero");

        ProductId = productId;
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}