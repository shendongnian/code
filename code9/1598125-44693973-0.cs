    public class ViewModel
    {
       public ViewModel()
       { 
           this.Price = 0;
       }
    
       [Display(Name = "Retail")]
       public double Price { get; set; }    
    }
