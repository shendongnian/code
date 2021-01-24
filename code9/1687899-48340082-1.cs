    public class City
    {
        [Key]
        public int Id { get; set; }
        public string CityName{ get; set; }
        public string Region{ get; set; }
        public int CountryID { get; set; }
        
        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
    }
    public class Country
    {   
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string CountryName{ get; set; }
        [Required]
        public string Continent{ get; set; }
        [Required]
        public string Capital{ get; set; }
    
        [Required]
        public int NumberOfPeople{ get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<City> Cities { get; set; }
    }
