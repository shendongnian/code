    using Newtonsoft.Json.Linq;
    public class JsonDoc
    {
        //I am adding an index on constructor for looping purposes
        public JsonDoc(string json, int index)
        {
            JObject jObject = JObject.Parse(json);
            //Add an index of zero so that it will read the result node
            JToken jResult = jObject["result"][0];
            codedoc = (string)jResult[index]["CODE_DOC"].Value<string>();
            nomdoc = (string)jResult[index]["NOM_DOC"].Value<string>();
            codecat = (string)jResult[index]["CODE_CAT"].Value<string>();
            versions = jResult[index]["VERSIONS"].ToArray();
        }
        public string codedoc { get; set; }
        public string nomdoc { get; set; }
        public string codecat { get; set; }
        public Array versions { get; set; }
    }
