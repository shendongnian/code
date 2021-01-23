    [Table("dbo.Cities")]
    public class City
    {
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string CityNameAr { get; set; }
        [Required]
        public virtual Country Country { get; set; }
    }
