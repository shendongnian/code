    public class Command {
       [JsonProperty("command")]
       public string Command { get; set;}
     
       [JsonProperty("axis")]
       public string Axis { get; set;}
    
       [JsonProperty("distance")]
       public double Distance { get; set;}
    
       [JsonProperty("interval")]
       public double Interval { get; set;}
    
       [JsonProperty("valueName")]
       public string ValueName { get; set;}
    
       [JsonProperty("newValue")]
       public int NewValue { get; set;}
    }
    
    var commandList = JsonConvert.Deserialize<List<Command>>(rawTextOfCommandFile);
