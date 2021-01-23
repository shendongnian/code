    using System.ComponentModel.DataAnnotations;
    public class AddViewModel
    {
         [Required(ErrorMessage = "Please enter a name")]
         [Display(Name = "Username")]
         [DataType(DataType.Text)]
         public string Name { get; set; }
         public string State{ get; set; }
         [Required]
         [DataType(DataType.EmailAddress)]
         public string Email{ get; set; }
         [Required]
         [DataType(DataType.PhoneNumber)]
         public string PhoneNumber{ get; set; }
    
         public AddViewModel()
         {}
    }
