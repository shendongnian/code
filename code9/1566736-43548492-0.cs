    public class JsonData //name this something relevant to your data.
    {
        public int Userid { get; set; }
        public int Id { get; set; }
        public static JsonData[] Deserialize(string jsonString)
        {
            return JsonConvert.DeserializeObject<JsonData[]>(jsonString);
        }
    }
