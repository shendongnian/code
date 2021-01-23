    public class RegisterViewModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
    
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
    
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            public string ConfirmPassword { get; set; }
    
            public virtual string DistrictName { get; set; }
    
            public virtual SelectList DistrictList { get; set; }
    
        }
        public class DistrictModel
        {
            public int DistrictID { get; set; }
            public string DistrictName { get; set; }
        }
    
        public class CombinedModel
        {
            public RegisterViewModel RegisterViewModel { get; set; }
            public DistrictModel Districtmodel { get; set; }
        }
