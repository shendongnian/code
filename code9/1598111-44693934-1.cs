    public class YourModel
    {
       public YourModel()
       { 
           this.Price = 0;
       }
       
       [Display(Name = "Retail")]
       [Required]
       public double Price { get; set; }
    
    }
