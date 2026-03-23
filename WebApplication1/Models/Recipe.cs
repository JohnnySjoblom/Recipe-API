using System.Collections.Generic;
namespace WebApplication1.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;

    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Quantity { get; set; } = string.Empty;

    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
}