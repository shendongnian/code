    public class RegisterViewModel
    {
       [Required]
       [Display(Name = "Country")]
       public int SelectedCountry { set;get;}
    
       public SelectList Countries { get; set; }
    
       //Your existing properties goes here
    }
