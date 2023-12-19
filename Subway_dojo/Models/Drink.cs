using Subway_dojo.Enum;

namespace Subway_dojo.Models;

public class Drink : OrderItem
{
    public Flavor Flavor { get; private set; }

    public Drink(Flavor flavor, decimal price) : base(price)
    {
        Flavor = flavor;
    }
}