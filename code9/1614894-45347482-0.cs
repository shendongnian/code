    public enum UnitOfMeasurement
    {
        Grams,
        Milliliters
    }
    
    public class Ingredient
    {
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
    
        public decimal Unit { get; set; }
    
        public string Name { get; set; }
    }
    
    public class Recipe
    {
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> RecipeSteps { get; set; }
    }
