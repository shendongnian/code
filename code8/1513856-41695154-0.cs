    public class RecipeCategory
    {
     [Key][DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int RecipeCategoryID { get; set; }
        public string Name { get; set; }
        public List<Recipe> Recipe { get; set; }
    }
    
    
    public class Recipe
    {
          
        public int ID { get; set; }
       
        public virtual int RecipeCategoryID { get; set; }
    
        [ForeignKey("RecipeCategoryID ")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    
        public string Title { get; set; }
        public string  Description { get; set; }
    
        public int RecipeCategoryID { get; set; }
        public RecipeCategory RecipeCategory { get; set; }
    }
    
    
       
