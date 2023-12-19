namespace Subway_dojo.Models;

public class Restaurant
{
    public string Name { get; private set; }
    public List<OrderItem> Orders { get; private set; }

    public Restaurant(string name)
    {
        Name = name;
        Orders = new List<OrderItem>();
    }
}