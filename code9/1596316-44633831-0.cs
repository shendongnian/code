    public class Person
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    	
    	[JsonProperty(PropertyName = "PhoneNumber")]
    	public PhoneNumberModel { get; set; }
    }
    
    public class PhoneNumberModel
    {
    	public int CCode { get; set;}
    	public int Area { get; set;}
    	public string PhoneNum { get; set; }
    	public string PhoneExtn { get; set; }
    }
    
    var person = JsonConvert.DeserializeObject<Person>(json);
    var name = person.Name;
    var phoneNumber = person.PhoneNumberModel;
