using System.Collections.Generic;

namespace DrinkSuggestions.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DrinkIngredient> DrinkIngredients { get; set; }
    }
}