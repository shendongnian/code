    using Newtonsoft.Json;
    class Program
    {
        static void Main( string[] args )
        {
            var jsonString = "{\"0abc34m\":{\"time\":\"13 Mar 17, 4:50:02 PM\",\"pd\":\"oscar\"}}";
            Dictionary<string, Data> data;
            data = JsonConvert.DeserializeObject<Dictionary<string, Data>>( jsonString );
            var key = data.First().Key; // 0abc34m
            var time = data.First().Value.TimeString; // 13 Mar 17, 4:50:02 PM
            var pd = data.First().Value.DataString; // oscar
        }
    }
    public class Data
    {
        [JsonProperty("time")]
        public string TimeString { get; set; }
        [JsonProperty("pd")]
        public string DataString { get; set; }
    }
