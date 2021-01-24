    public class EntityDetails
    {
        (...)
        public Newtonsoft.Json.Linq.JObject Data { get; set; }
    }
    (...)
    var x = JsonConvert.DeserializeObject<EntityDetails>(jsonString);
    var dataAsString = x?.Data?.ToString();
