    [DataContract]    
    public class Value
    {
    [DataMember]
    public List<string> ColumnNames { get; set; }
    [DataMember]
    public List<string> ColumnTypes { get; set; }
    [DataMember]
    public List<List<string>> Values { get; set; }
    }
    [DataContract]
    public class Output1
    {
    [DataMember]
    public string type { get; set; }
    [DataMember]
    public Value value { get; set; }
    }
    [DataContract]
    public class Results
    {
    [DataMember]
    public Output1 output1 { get; set; }
    }
    [DataContract]
    public class RootObject
    {
    [DataMember]
    public Results Results { get; set; }
    }
