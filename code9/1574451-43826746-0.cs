    [Required(ErrorMessage = "Departure date is required")]
    [Display(Name = "Departure Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DepartureDate { get; set; }
