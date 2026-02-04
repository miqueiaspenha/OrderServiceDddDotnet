using OrderService.Domain.Entities;
using OrderService.Domain.Enums;
using Xunit;


namespace OrderService.Domain.Tests;

public class OrderTests
{
    [Fact]
    public void New_order_should_start_as_draft()
    {
        var order = new Order();
        Assert.Equal(OrderStatus.Draft, order.Status);
    }

    [Fact]
    public void Should_add_item_to_draft_order()
    {
        var order = new Order();
        var item = new OrderItem(Guid.NewGuid(), "Product A", 2, 10m);

        order.AddItem(item);

        Assert.Single(order.Items);
        Assert.Equal(20m, order.Total);
    }

    [Fact]
    public void Should_not_confirm_order_with_items()
    {
        var order = new Order();
        Assert.Throws<InvalidOperationException>(() => order.Confirm());
    }

    [Fact]
    public void Should_confirm_order_with_items()
    {
        var order = new Order();
        order.AddItem(new OrderItem(Guid.NewGuid(), "Product A", 1, 50m));
        order.Confirm();
        Assert.Equal(OrderStatus.Confirmed, order.Status);
    }

    [Fact]
    public void Should_not_modify_confirmed_order()
    {
        var order = new Order();
        order.AddItem(new OrderItem(Guid.NewGuid(), "Product A", 1, 50m));
        order.Confirm();

        Assert.Throws<InvalidOperationException>(() =>
            order.AddItem(new OrderItem(Guid.NewGuid(), "Produtc B", 1, 30m))
        );
    }
}