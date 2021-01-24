    First:
    public class JsonData {
    public string time {get; set;}
    public string high {get; set;}
    etc...
    }
    
    Second:
    public class DataRoot {
    public string Response {get; set:}
    public string Type {get; set:}
    public bool Aggregated{get; set:}
    public List<JsonData> Data{get; set:}
    }
    
    var root = JsonConvert.DeserializeObject<DataRoot>(YOUR JSON STRING HERE);
    var rootData = root.Data;
