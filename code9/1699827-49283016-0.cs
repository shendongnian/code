    [DataContract]
    public class RuntimeValue
    {
    	public Purpose Purpose { get; set; }
    
    	[DataMember(Name = "Purpose")]
    	string PurposeString
    	{
    		get { return Enum.GetName(typeof(Purpose), this.Purpose).FirstCharacterToLower(); }
    		set { this.Purpose = (Purpose)Enum.Parse(typeof(Purpose), value); }
    	}
    }
