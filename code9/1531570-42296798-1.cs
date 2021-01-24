    public class A10b4b1e840046138c905d282de6a8a6
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<int> center { get; set; }
        public string timeZoneCode { get; set; }
        public object languageCode { get; set; }
    }
    public class Dc3d9d82611e41baA6f62c33ac5eebd1
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<int> center { get; set; }
        public string timeZoneCode { get; set; }
        public object languageCode { get; set; }
    }
    public class Territories
    {
	    [JsonProperty("a10b4b1e-8400-4613-8c90-5d282de6a8a6")]
        public A10b4b1e840046138c905d282de6a8a6 A10b4b1e840046138c905d282de6a8a6{get; set;}
	    [JsonProperty("dc3d9d82-611e-41ba-a6f6-2c33ac5eebd1")]
	    public Dc3d9d82611e41baA6f62c33ac5eebd1 Dc3d9d82611e41baA6f62c33ac5eebd1{get; set;}
    }
    public class RootObject
    {
	    public Territories territories{get; set;}
    }
