    [Required]
    public string FirstName { get; set; }
    
    [StringLength(50, ErrorMessage = "The Last Name must be less than {1} characters.")]
    public string LastName { get; set; }
