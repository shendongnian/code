    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class Activity
    {
        public Guid Id { get; set; }
        public String ActivityID { get; set; }
        public String Title { get; set; }
        public String Status { get; set; }
    
        public ActivityType TypeOfActivity { get; set; }
    }
