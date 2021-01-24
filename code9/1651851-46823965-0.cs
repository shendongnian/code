    public class Data
    {
        public string personaname { get; set; } 
    }
    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Data>(jsonString);
    // use data.personaname
