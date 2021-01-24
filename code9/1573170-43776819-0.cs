    public class JsonDoc
    {
        //I am adding an index on constructor for looping purposes
        public JsonDoc(string json, int index)
        {
            JObject jObject = JObject.Parse(json);
            JToken jResult = jObject["ClaimList"];
            Claims = jResult[index]["Claims"].ToObject<string[]>();
        }
        //This constructor will return the number of count under ClaimList node
        public JsonDoc(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jResult = jObject["ClaimList"][0];
            intCount = jResult.Count();
        }
        private string[] Claims { get; set; }
        public int intCount { get; set; }
    }
