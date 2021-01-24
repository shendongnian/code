    public class Product
    {
       [Key]
       public Guid ProductId {get; set;}
    
       [ForeignKey("RecipeId")]
       public virtual Recipe Recipe {get; set;}
    
       public Guid RecipeId {get; set;}
    
       // ...
    }
