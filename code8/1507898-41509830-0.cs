    public class Login 
    {    
            [Display(Name = "Username")]
            public string USERNAME { get; set; }
    
            [Display(Name = "Password")]
            [DataType(DataType.Password)]
            public string PASSWORD { get; set; }        
    }
