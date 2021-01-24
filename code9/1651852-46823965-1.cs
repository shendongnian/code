    public class Player
    {
        public string personaname { get; set; } 
    }
    var player = Newtonsoft.Json.JsonConvert.DeserializeObject<Player>(jsonString);
    // use player.personaname
