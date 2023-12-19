using Subway_dojo.Enum;
using Subway_dojo.Models;
using Subway_dojo.Services;

class Program
{
    static void Main(string[] args)
    {
        // Initialize restaurant
        var restaurant = new Restaurant("Subway");

        // Initialize the order service with the restaurant
        var orderService = new OrderService(restaurant);

        // Create and add orders
        orderService.AddOrder(new Drink(Flavor.CocaCola, 750));
        orderService.AddOrder(new Sandwich(new List<Ingredient>
        {
            new Ingredient("Bread", 1000),
            new Ingredient("Ham", 350),
            new Ingredient("Cheese", 250)
        }));

        // Calculate and display total income
        Console.WriteLine(
            $"Total Income: {orderService.CalculateTotalIncome()} HUF");
    }
}