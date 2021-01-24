    public class Visit
    {
        public int Id { get; set; }
    
        [Required]
        public VisitStatus Status { get; set; }
    
        [Required]
        public double? Latitude { get; set; }
    
        [Required]
        public double? Longitude { get; set; }
    
        public Location Location { get; set; }
    
        [Required]
        public DateTime Date { get; set; }
    
        public string Street { get; set; }
    
        public int? StreetNumber { get; set; }
    
        public string StreetNumberLetter { get; set; }
    
        public string StreetNumberLetterAddition { get; set; }
    
        public string City { get; set; }
    }
    
    public struct Location
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
