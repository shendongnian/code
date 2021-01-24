    [DataContract]
    public class Category
    {
        [DataMember] public string prop1 { get; set; }
        [DataMember] public string prop2 { get; set; }
    }
    [DataContract]
    public class Data
    {
        [DataMember]
        public Dictionary<int, Category> categories { get; set; }
    }
    [DataContract]
    public class RootObject
    {
        [DataMember]
        public int code { get; set; }
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public Data data { get; set; }
    }
    static void Main(string[] args)
    {
        var root = new RootObject()
        {
            code = 1,
            message = "test",
            data = new Data()
            {
                categories = new Dictionary<int, Category>()
                {
                    { 0, new Category()
                        {
                            prop1 = "cat1prop1",
                            prop2 = "cat1prop2"
                        }
                    },
                    { 1,  new Category()
                        {
                            prop1 = "cat2prop1",
                            prop2 = "cat2prop2"
                        }
                    }
                }
            }
        };
        var testJson = "{code: 200,message: \"success\",data: {categories: {0: {prop1: 100,prop2: \"blah\"},1: {prop1: 100,prop2: \"blah\"}}}}";
        var json = JsonConvert.SerializeObject(root);
        var testConvert = JsonConvert.DeserializeObject<RootObject>(testJson);
    }
