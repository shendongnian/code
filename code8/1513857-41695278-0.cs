    public class Recipe
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string  Description { get; set; }
        [ForeignKey("RecipeCategory")]
        public int RecipeCategoryID { get; set; }
        public RecipeCategory RecipeCategory { get; set; }
    }
