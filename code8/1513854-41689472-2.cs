    public class YourContext: DbContext
    {
        public YourContext():
            base("yourConnectionString")
        {
        }
    
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
    }
