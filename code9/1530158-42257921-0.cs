    void Main()
    {
        var jsSer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Person));
        
        var p = new Person {
            ID = 1,
            name = "John",
            DOB = 1234.5,
            nameToken = "token"
        };
        
        string result = null;
        using (var ms = new MemoryStream())
        {
            jsSer.WriteObject(ms, p);
            byte[] json = ms.ToArray();
            ms.Close();
            
            result = Encoding.UTF8.GetString(json, 0, json.Length);
        }
        Console.WriteLine(result);
    }
    
    [DataContract]
    public class Person
    {
        //included
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string nameToken { get; set; }
        [DataMember]
        public double DOB { get; set; }
    
        //ignored
        public static int PSID = 1;
        public List<string> awards { get; set;  }
        public List<string> links { get; set; }
    
        public Person()
        {
    
            awards = new List<Award>();
            links = new List<Link>();
            ID = PSID;
            PSID++;
        }
    }
