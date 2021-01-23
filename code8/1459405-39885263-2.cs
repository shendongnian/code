    var hotkeyConfig = JObject.Parse(json);
    
    var playersToken = hotkeyConfig.SelectToken("hotkeySets");
    
    var playersDictionary = 
        JsonConvert.DeserializeObject<Dictionary<string, JObject>>(
            playersToken.ToString());
    
    foreach (var playerEntry in playersDictionary)
    {
        var player = JsonConvert.DeserializeObject<Player>(playerEntry.Value.ToString());
    }
