using Subway_dojo.Enum;
using Subway_dojo.Models;
using Subway_dojo.Services;

namespace SubwayTests;

[TestFixture]
public class OrderServiceTests
{
    [Test]
    public void CalculateTotalIncome_ReturnsCorrectTotal()
    {
        // Arrange
        var restaurant = new Restaurant("TestSubway");
        var orderService = new OrderService(restaurant);

        // Act
        orderService.AddOrder(new Drink(Flavor.CocaCola, 750));
        orderService.AddOrder(new Drink(Flavor.IceTea, 750));
        
        orderService.AddOrder(new Sandwich(new List<Ingredient>
        {
            new Ingredient("Bread", 1000),
            new Ingredient("Ham", 350),
            new Ingredient("Cheese", 250)
        }));
        orderService.AddOrder(new Sandwich(new List<Ingredient>
        {
            new Ingredient("Bread", 1000),
            new Ingredient("Bacon", 350),
            new Ingredient("Tomato", 200)
        }));

        var totalIncome = orderService.CalculateTotalIncome();

        // Assert
        Assert.That(totalIncome, Is.EqualTo(4650),
            "Total income calculation is incorrect.");
    }

    [Test]
    public void AddOrder_ShouldAddOrderToRestaurant()
    {
        // Arrange
        var restaurant = new Restaurant("TestSubway");
        var orderService = new OrderService(restaurant);
        var drink = new Drink(Flavor.Fanta, 750);
        
        // Act
        orderService.AddOrder(drink);
        
        // Assert
        Assert.That(restaurant.Orders.Contains(drink), Is.True, 
            "Order was not added to the restaurant.");
    }

    [Test]
    public void CalculateTotalIncome_WithNoOrders_ShouldReturnZero()
    {
        // Arrange
        var restaurant = new Restaurant("TestSubway");
        var orderService = new OrderService(restaurant);
        
        // Act
        var totalIncome = orderService.CalculateTotalIncome();
        
        // Assert
        Assert.That(totalIncome, Is.EqualTo(0), 
            "Total income should be zero when no orders are added.");
    }

    [Test]
    public void SandwichPrice_ShouldBeSumOfIngredients()
    {
        // Arrange
        var ingredients = new List<Ingredient>
        {
            new Ingredient("Bread", 1000),
            new Ingredient("Bacon", 350),
            new Ingredient("Letutce", 150),
            new Ingredient("Tomato", 150)
        };
        var sandwich = new Sandwich(ingredients);
        
        // Act
        var totalPrice = sandwich.Price;
        
        // Assert
        Assert.That(totalPrice, Is.EqualTo(1650), 
            "Sandwich price calculation is incorrect.");
    }

    [Test]
    public void DrinkCreation_WithDifferentFlavors_ShouldHaveCorrectProperties()
    {
        // Arrange & Act
        var cola = new Drink(Flavor.CocaCola, 750);
        var fanta = new Drink(Flavor.Fanta, 700);
        
        // Assert
        Assert.That(cola.Flavor, Is.EqualTo(Flavor.CocaCola), "CocaCola flavor is incorrect.");
        Assert.That(fanta.Flavor, Is.EqualTo(Flavor.Fanta), "Fanta flavor is incorrect.");
        Assert.That(cola.Price, Is.EqualTo(750), "CocaCola price is incorrect.");
        Assert.That(fanta.Price, Is.EqualTo(700), "Fanta price is incorrect.");
    }
}