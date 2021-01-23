    public class LoginModel {    
        [Required]
        [DataType(DataType.Text)]
        public string LoginUsername { get; set; }
    
        [Required]
        [DataType(DataType.Password)]
        public string LoginPassword { get; set; }
    }
