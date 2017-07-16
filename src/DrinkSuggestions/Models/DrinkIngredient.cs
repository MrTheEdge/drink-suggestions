namespace DrinkSuggestions.Models
{
    public class DrinkIngredient
    {
        public int DrinkId { get; set; }
        public Drink Drink { get; set; }
        public string Amount { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}