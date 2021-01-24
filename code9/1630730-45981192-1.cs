    public class RootObject
    {
        public bool status { get; set; }
        public int statusCode { get; set; }
        [JsonConverter(typeof(StringToResponseConverter))]
        public Response response { get; set; }
    }
