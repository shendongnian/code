    [DataContract]
	public class YourClass
	{
	    [DataMember]
	    public int Id { get; set; }
	    [DataMember]
	    public string Prop1 { get; set; }
	    //ignored
	    public string IgnoredProp { get;set; }
	}
