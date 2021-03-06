using System.Collections.Generic;

namespace DrinkSuggestions.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<DrinkIngredient> DrinkIngredients { get; set; }
    }
}