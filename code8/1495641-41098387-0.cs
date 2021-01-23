    public class Station
    {
        public int StationId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int? ServiceLevelId { get; set; }
        [ForeignKey("ServiceLevelId")]
        public virtual ServiceLevel ServiceLevel { get; set; }
    }
       
 
