    public class JsonPathAttribute : Attribute
    {
        public JsonPathAttribute(string jsonPath)
        {
            JsonPath = jsonPath;
        }
        public string JsonPath { get; set; }
    }
