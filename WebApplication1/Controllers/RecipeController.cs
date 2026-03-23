using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.DTOs;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly AppDbContext _context;

    public RecipesController(AppDbContext context)
    {
        _context = context;
    }

        [HttpGet]
            public async Task<IActionResult> GetAllRecipes()
            {
                var recipes = await _context.Recipes
                    .Select(r => new RecipeResponseDto
                    {
                        Id = r.Id,
                        Name = r.Name,
                    })
                        .ToListAsync();

                        return Ok(recipes);

            }

    
        [HttpGet("{id}")]
            public async Task<IActionResult> Get(int id)
            {
                var recipe = await _context.Recipes.FindAsync(id);

                if (recipe == null)
                    return NotFound("Recipe not found");

                    return Ok(new RecipeResponseDto
                    {
                        Id = recipe.Id,
                        Name = recipe.Name,
                    });
        
            }
    
        [HttpPost]
            public async Task<IActionResult> Create(RecipeCreateDto dto)
            {
                if (string.IsNullOrEmpty(dto.Name))
                    return BadRequest("Name is required");

                    var recipe = new Recipe
                    {
                    Name = dto.Name,
                    Instructions = dto.Instructions
                    };

                    _context.Recipes.Add(recipe);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction(nameof(Get), new { id = recipe.Id }, recipe);

            }   

        [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, RecipeCreateDto dto)
            {
                var recipe = await _context.Recipes.FindAsync(id);

                if (recipe == null)
                    return NotFound("Recipe not found");

                    recipe.Name = dto.Name;
                    recipe.Instructions = dto.Instructions;

                    await _context.SaveChangesAsync();

                    
                    return NoContent();

            }

        [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var recipe = await _context.Recipes.FindAsync(id);
        
                if (recipe == null)
                    return NotFound("Recipe not found");
        
                    _context.Recipes.Remove(recipe);
                    await _context.SaveChangesAsync();
        
                    return NoContent();
            }


        [HttpGet("{id}/ingredients")]
            public async Task<IActionResult> GetIngredientsForRecipe(int id)
            {
                var recipe = await _context.Recipes
                    .Include(r => r.Ingredients)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (recipe == null)
                    return NotFound("Recipe not found");

                    var ingredients = recipe.Ingredients.Select(i => new IngredientDto
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Quantity = i.Quantity
                    });
                    
                    return Ok(ingredients);
            }




}

       
    