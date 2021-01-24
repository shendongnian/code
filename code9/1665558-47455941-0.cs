    public class FacebookDataUser
        {
            [Key,JsonProperty("id")]
            public string FacebookDataUserId { get; set; }
            public string name { get; set; }
            public string birthday { get; set; }
            public string email { get; set; }
            public virtual Hometown Hometown { get; set; }
            public virtual Location Location { get; set; }
            public virtual Events Events { get; set; }
            public virtual Likes Likes { get; set; }
            public virtual Age_Range Age_Range { get; set; }
            public string gender { get; set; }
        }
    
        public class Hometown
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int HometownId { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            
        }
    
        public class Location
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int LocationId { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            
        }
    
        public class Events
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int EventsId { get; set; }
            [JsonProperty("data")]
            public ICollection<EventData> EventDatas { get; set; }
        }
    
        public class EventData
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int EventDataId { get; set; }
            public string description { get; set; }
            public string name { get; set; }
            [Column(TypeName = "datetime2")]
            public DateTime start_time { get; set; }
            public virtual Place Place { get; set; }
            public int attending_count { get; set; }     
            public string type { get; set; }
            public string rsvp_status { get; set; }
            [Column(TypeName = "datetime2")]
            public DateTime end_time { get; set; }
        }
    
        public class Place
        {
            [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int PlaceId { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            [JsonProperty("location")]
            public virtual LocationEvent LocationEvent { get; set; }
        }
    
        public class LocationEvent
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int LocationEventId { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public float latitude { get; set; }
            public float longitude { get; set; }
            public string state { get; set; }
            public string street { get; set; }
            public string zip { get; set; }
        }
    
        public class Likes
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int LikesId { get; set; }
            [JsonProperty("data")]
            public virtual ICollection<LikesData> LikesData { get; set; }
        }
    
        public class LikesData
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int LikesDataId { get; set; }
            public string id { get; set; }
            public string category { get; set; }
            public string name { get; set; }
            public int fan_count { get; set; }
            public string website { get; set; }
            [JsonProperty("location")]
            public virtual LocationEvent LocationEvent { get; set; }
            [JsonProperty("emails")]
            public virtual ICollection<string> emails { get; set; }
        }
    
        public class Age_Range
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Age_RangeId { get; set; }
            public int min { get; set; }
        }
