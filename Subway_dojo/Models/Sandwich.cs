namespace Subway_dojo.Models;

public class Sandwich : OrderItem
{
    public List<Ingredient> Ingredients { get; private set; }

    public Sandwich(List<Ingredient> ingredients)
        : base(ingredients.Sum(i => i.Price))
    {
        Ingredients = ingredients;
    }
}