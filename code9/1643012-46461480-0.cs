    [Required]
    [NotMapped]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Please confirm your password again")]
    public string ConfirmPassword { get; set; }
