    public class RootObjectDeserializer
    {
        List<RootObject> DeserializeRoot()
        {
            // Read string from somewhere
            string json = "[{\"prioritycode\":{\"High\":{\"High\":1},\"Normal\":{\"Normal\":2},\"Low\":{\"Low\":3}}},{\"isescalated\":{\"Yes\":{\"Yes\":1},\"No\":{\"No\":0}}},{\"firstresponsesent\":{\"Yes\":{\"Yes\":1},\"No\":{\"No\":0}}}]";
            // Deserialize to a List of RootObject
            List<RootObject> deserializedObjects = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RootObject>>(json);
            // Return RootObject
            return deserializedObjects;
        }
    }
    //Class mappings below
    public class High
    {
        [JsonProperty("High")]
        public int HighProperty { get; set; }
    }
    public class Normal
    {
        [JsonProperty("Normal")]
        public int NormalProperty { get; set; }
    }
    public class Low
    {
        [JsonProperty("Low")]
        public int LowProperty { get; set; }
    }
    public class Prioritycode
    {
        public High High { get; set; }
        public Normal Normal { get; set; }
        public Low Low { get; set; }
    }
    public class Yes
    {
        [JsonProperty("Yes")]
        public int YesProperty { get; set; }
    }
    public class No
    {
        [JsonProperty("No")]
        public int NoProperty { get; set; }
    }
    public class Isescalated
    {
        public Yes Yes { get; set; }
        public No No { get; set; }
    }
    public class Yes2
    {
        public int Yes { get; set; }
    }
    public class No2
    {
        public int No { get; set; }
    }
    public class Firstresponsesent
    {
        public Yes2 Yes { get; set; }
        public No2 No { get; set; }
    }
    public class RootObject
    {
        public Prioritycode prioritycode { get; set; }
        public Isescalated isescalated { get; set; }
        public Firstresponsesent firstresponsesent { get; set; }
    }
