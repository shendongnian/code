    public class Site
    {
        [Required(ErrorMessage = "SiteID can't be null")]
        public int SiteID { get; set; }
        [Required]
        public int House { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z][a-zA-Z ]*$")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        [RegularExpression("^[A-Z][A-Z]$", ErrorMessage = "Incorrect zip code.")]
        public string State { get; set; }
        [Required]
        [RegularExpression("^[0-9][0-9]*$")]
        public string Zip { get; set; }
        public int Apartment { get; set; }
    }
