    public class DataClass
    {
       public string Name { get; set; }
       //Ignored
       [JsonIgnore]
       public string Value { get; set; }
       [JsonIgnore]
       public int SortOrder { get; set; }
    }
