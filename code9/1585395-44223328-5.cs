    [DataContract]
    public class Computer
    {
        // included in JSON
        [DataMember]
        public GeoPoint Point { get; set; }
        // ignored
        public DbGeography Location { get; set; }
    }
