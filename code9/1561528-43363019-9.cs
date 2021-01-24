     public class UserEdit
        {
            [Display(Name = "Email")]
            public string Email { get; set; }
    
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
    
            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
    
     
            [Display(Name = "Mobile")]
            public string Mobile { get; set; }
    
           
            [Display(Name = "Address")]
            public string Address { get; set; }
    
    
            [Display(Name = "City")]
            public string City { get; set; }
    
            public bool EmailConfirmed { get; set; }
        }
