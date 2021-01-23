    public class RecipeCategory
    {
        public int RecipeCategoryID { get; set; }
        public string Name { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
    public class Recipe
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string  Description { get; set; }
    
        public int RecipeCategoryID { get; set; }
        public RecipeCategory RecipeCategory { get; set; }
    }
