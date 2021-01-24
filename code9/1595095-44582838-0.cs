    public class Body
    {
        [JsonProperty("contentType")]
        public string contentType { get; set; }
        [JsonProperty("content")]
        public string content { get; set; }
    }
    public class Start
    {
        [JsonProperty("dateTime")]
        public DateTime dateTime { get; set; }
        [JsonProperty("timeZone")]
        public string timeZone { get; set; }
    }
    public class End
    {
        [JsonProperty("dateTime")]
        public DateTime dateTime { get; set; }
        [JsonProperty("timeZone")]
        public string timeZone { get; set; }
    }
    public class Address
    {
    }
    public class Location
    {
        [JsonProperty("displayName")]
        public string displayName { get; set; }
        [JsonProperty("address")]
        public Address address { get; set; }
    }
    public class Status
    {
        [JsonProperty("response")]
        public string response { get; set; }
        [JsonProperty("time")]
        public DateTime time { get; set; }
    }
    public class EmailAddress
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("address")]
        public string address { get; set; }
    }
    public class Attendee
    {
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("status")]
        public Status status { get; set; }
        [JsonProperty("emailAddress")]
        public EmailAddress emailAddress { get; set; }
    }
    public class Organizer
    {
        [JsonProperty("emailAddress")]
        public  emailAddress { get; set; }
    }
    public class Value
    {
        [JsonProperty("@odata.etag")]
        public string @odata.etag { get; set; }
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("subject")]
        public string subject { get; set; }
        [JsonProperty("bodyPreview")]
        public string bodyPreview { get; set; }
        [JsonProperty("body")]
        public Body body { get; set; }
        [JsonProperty("start")]
        public Start start { get; set; }
        [JsonProperty("end")]
        public End end { get; set; }
        [JsonProperty("location")]
        public Location location { get; set; }
        [JsonProperty("attendees")]
        public IList<Attendee> attendees { get; set; }
        [JsonProperty("organizer")]
        public Organizer organizer { get; set; }
    }
    public class Rootobject
    {
        [JsonProperty("@odata.context")]
        public string @odata.context { get; set; }
        [JsonProperty("@odata.nextLink")]
        public string @odata.nextLink { get; set; }
        [JsonProperty("value")]
        public IList<Value> value { get; set; }
    }
