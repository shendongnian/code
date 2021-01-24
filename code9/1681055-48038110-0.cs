    public int IdRoom { get; set; }
    [Required(ErrorMessage = "Veuillez saisir votre prénom.")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Veuillez saisir votre nom.")]
    public string LastName { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime Checkin { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime Checkout { get; set; }
    public decimal Price { get; set; }
