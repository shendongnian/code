    class Result
    {
        [JsonProperty("game_count")]
        public string Count { get; set; }
        [JsonProperty("games")]
        public List<Game> Gmaes { get; set; }    
    }
    
    class Game 
    {
        [JsonProperty("appid")]
        public string Id { get; set; }
        [JsonProperty("playtime_forever")]
        public string PlayTime { get; set; }
    }
    var response = JsonConvert.DeserializeObject<Result>(jsonstr);
