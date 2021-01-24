    public class Ingredient
    {
        public int IngredientsId { get; set; }
        public UnitNames Unit { get; set; }
        public int IngredientId { get; set; }
        public double Amount { get; set; }
    }
    public List<Ingredient> GetRecipe(int recipeId)
    {
        return (from c in db.RecipeIngredients
           join d in db.Ingredients on c.IngredientID equals d.IngredientsID
           where c.RecipeID.Equals(recipeID)
           select new Ingredient { 
                                     IngredientsId = d.IngredientsID, 
                                     Unit = c.Unit,
                                     IngredientId = c.IngredientID, 
                                     Amount = c.Amount 
                                 }).ToList();
    }
