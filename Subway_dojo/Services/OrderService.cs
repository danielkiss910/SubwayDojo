using Subway_dojo.Models;

namespace Subway_dojo.Services;

public class OrderService
{
    private Restaurant _restaurant;

    public OrderService(Restaurant restaurant)
    {
        _restaurant = restaurant;
    }


    public void AddOrder(OrderItem order)
    {
        _restaurant.Orders.Add(order);
    }

    public decimal CalculateTotalIncome()
    {
        return _restaurant.Orders.Sum(order => order.Price);
    }
}