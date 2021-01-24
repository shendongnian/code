    public class Rootclass
    {
        public List<Class1> rootClass { get; set; }
    }
    public class Class1
    {
        public string value { get; set; }
        public string datevalue { get; set; }
        public string winflag { get; set; }
        public string idmercado { get; set; }
    }
    List<List<Class1>> myDeserializedObjList =
            JsonConvert.DeserializeObject<List<List<Class1>>>(json);
