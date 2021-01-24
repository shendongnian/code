    public class YourModel
    {
       
       [Required(ErrorMessage = "Price is required")]
       [Display(Name = "Retail")]
       [Range(0, double.MaxValue)]
       public double Price { get; set; }
       
    }
    
