    public class Person {
        public string Id { get; set; }
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        [JsonIgnore]
        public string FirstName { get; set; }
        [JsonIgnore]
        public string LastName { get; set; }
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonIgnore]
        public string Address1 { get; set; }
        [JsonIgnore]
        public string Address2 { get; set; }
		[OnSerializing]
		internal void OnSerializing(StreamingContext context) {
			Street = (Address1 + " " + Address2).Trim();
		}
		[OnDeserialized]
		internal void OnDeserialized(StreamingContext context) {
			Address1 = Street;
		}
    }
    // C# Object
    var p = new Person() {
        Id = 123,
        FirstName = "John",
        LastName = "Doe",
        Address1 = "456 Main St",
        Address2 = "Apt 2"
    }
    // Json to output and consume
    { "id": 123, "fullName": "John Doe", "street": "456 Main St Apt 2" }
