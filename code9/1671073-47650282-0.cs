    [DataContract]
    public class Contest
    {
        [DataMember(Order = 0)]
        public int ContestID { get; set; }
    
        [DataMember(Order = 1)]
        public string MovieName { get; set; }
    
        [DataMember(Order = 2)]
        public string MovieImage { get; set; }
    
        [DataMember(Order = 3)]
        public string RegionalMovieName{get;set;}
    
        // ... the pattern should be clear
    }
