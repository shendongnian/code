    public class Rootobject
    {
        public Myobj myObj { get; set; }
        public string myStr { get; set; }
    }
    public class Myobj
    {
        [DefaultValue("")]
        public string x { get; set; }
        [DefaultValue("")]
        public string y { get; set; }
    }
    var originalSerializedObject = "{myObj: { x: \"\", y: \"test str\" }, myStr: \"hello world!\"}";
    var deserializedObject = JsonConvert.DeserializeObject<Rootobject>(originalSerializedObject);
    var serializerSettings = new JsonSerializerSettings 
                                 { 
                                    NullValueHandling = NullValueHandling.Ignore, 
                                    DefaultValueHandling = DefaultValueHandling.Ignore 
                                 };
    var newSerializedObject = JsonConvert.SerializeObject(deserializedObject, serializerSettings);
    Console.WriteLine(newSerializedObject);
    //{"myObj":{"y":"test str"},"myStr":"hello world!"}
