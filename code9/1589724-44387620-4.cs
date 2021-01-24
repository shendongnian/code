    //inside you model.
        [Required]
        [Remote("IsEmailAvailable", "YourControllerName")]
        [RegularExpression(@"Your email address validation regex here", ErrorMessage = "Email address is not valid .")]
        [Editable(true)]
        public string Email{ get; set; }
