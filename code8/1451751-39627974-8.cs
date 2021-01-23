    public class Location
    {
        [Key]  //mark location ID as primary key
        public int LocationID { get; set; }
    
        [Index]
        [StringLength(48)]
        public string Name  { get; set; }
    
        [Index]
        public State State { get; set; }
    
        public double Latitude  { get; set; }
        public double Longitude { get; set; }
    
        public virtual List<Profile> Profiles { get; set; }
    }
