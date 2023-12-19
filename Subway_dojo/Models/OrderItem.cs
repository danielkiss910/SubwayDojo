namespace Subway_dojo.Models;

public abstract class OrderItem
{
    public decimal Price { get; protected set; }

    protected OrderItem(decimal price)
    {
        Price = price;
    }
}