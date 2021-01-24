        [Key]
		[Display(Name = "FIRST NAME")]
        public string FirstName { get; set; }
        
		[Display(Name = "LAST NAME")]
        public string LastName { get; set; }
        
		[Display(Name = "DATE OF BIRTH")]
        public int Age { get; set; }
        
		[Display(Name = "ADDRESS")]
        public string Address { get; set; }
        
		[Display(Name = "CELLPHONE NUMBER")]
        public int MobileNumber { get; set; }
        
		[Display(Name = "EMAIL ADDRESS")]
        [Required(ErrorMessage = "PLEASE ENTER VALID EMAIL ADDRESS")]
        public string Email { get; set; }
        
		[Display(Name = "USERNAME")]
        [Required(ErrorMessage = "PLEASE ENTER YOUR USERNAME")]
        public string Username { get; set; }
        
		[Display(Name = "PASSWORD")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "PLEASE ENTER YOUR PASSWORD")]
        public string Password { get; set; }
        
