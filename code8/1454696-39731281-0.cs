     public class Datum
    {
    public string data1 { get; set; }
    public string data2 { get; set; }
    public string data3 { get; set; }
    public string connectorType { get; set; }
    public string sourceUri { get; set; }
    public string destinationUri { get; set; }
    public string rails { get; set; }
    public string data6 { get; set; }
    public string groupId { get; set; }
    public string failbackAction { get; set; }
    public string normal { get; set; }
    public string failoverAction { get; set; }
    public string artifactId { get; set; }
    public string normalState { get; set; }
    public string instanceId { get; set; }
    }
    public class RootObject
    {
    public string appname { get; set; }
    public string key { get; set; }
    public List<Datum> data { get; set; }
    public string updateId { get; set; }
    public string updateTS { get; set; }
    public string creationUser { get; set; }
    }
