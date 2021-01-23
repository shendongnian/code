    [DataContract]
    public class Demo : DynamicObject
    {
     // This property is ignore in api response
     [DataMember]   OR [JsonProperty]
     public int Prop1 {get; set;}
    }
