    [Required]
    [Display(Name = "Game time")]
    [DataType(DataType.Time)]
    public TimeSpan? Time { get; set; }
    
    [Required]
    [FutureDate]
    [Display(Name = "Game date")]
    [DataType(DataType.Date)]
    public DateTime? Date { get; set; }
