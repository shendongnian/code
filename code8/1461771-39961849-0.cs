    public class MemberBooking
        {
            [JsonProperty("course_id")]
            public int CourseId { get; set; }
        
            [JsonProperty("date")]
            public string TeeDate { get; set; }
        
            [JsonProperty("time")]
            public string TeeTime { get; set; }
        
            [JsonProperty("slots")]
            public Dictionary<int,MemberSlot> Slots { get; set; }
        }
