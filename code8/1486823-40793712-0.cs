    public class A{
    
        // ... stuff 
        [Required]
        [Display(Name = "Price (Euros)")]
        [Range(1, 1000)]
        public float Price { get; set; }
    
        // ... more stuff 
    }
    
    public class B : A{
    
        // ... stuff 
    
        // ... more stuff 
    }
