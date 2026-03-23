namespace WebApplication1.Models;

public class Ingredients
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Quantity { get; set; } = string.Empty;

    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
}