    public class CoordinatesModel
    {
        [Key]       
        public int Id { get; set; }
        [Required]
        public float Longitude { get; set; }
        [Required]
        public float Latitude { get; set; }
        [ForeignKey("Id")]
        public virtual PointOfInterestModel PointOfInterest { get; set; }
    }
