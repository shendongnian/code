     public class RegisterViewModel
     { 
       [Required]
                                        [DisplayName("User Name")]
                                        public string UserName { get; set; }
                                        [Required]
                                        [Remote("EmailAlreadyExists", "Validation", ErrorMessage = "User with this mail exists")]
                                        [DisplayName("Email")]
                                        public string Email { get; set; }
                                        [Required]
                                        [DisplayName("Password")]
                                        public string Password { get; set; }
                                        [Required]
                                        [DataType(DataType.Password)]
                                        [DisplayName("Confirm Password")]
                                        public string ConfirmPassword { get; set; }
                                        [Required]
                                        public IEnumerable<SelectListItem> Roles { get; set; }
       **public string SelectedRole {get;set;}**
     }
