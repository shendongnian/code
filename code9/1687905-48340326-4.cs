    pubic class City 
    {
        [Key]
        public int Id { get; set; }
        public string CityName{ get; set; }
        public string Region{ get; set; }
        [ForeignKey(“Country”)]
        public int CountryID { get; set; }
        public Country Country { get; set; }
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
        public virtual ICollection<City> Cities { get; set; }
    }
