    [JsonConverter(typeof(JsonObjectConverter))]
    public class JsonObject
    {
        public JsonObject(IDataObject dataObject)
        {
            this.DataObject= dataObject;
        }
        [JsonIgnore]
        public IDataObject DataObject;
    }
