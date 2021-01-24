        public class RecipeDbContext : DbContext
        {
            public DbSet<Recipe> Recipes { get; set; }
            public DbSet<RecipeCategory> Categories { get; set; }
            public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
                : base(options)
            { }
        }
