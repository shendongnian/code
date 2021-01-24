    [DataContract]
    public class AccountSummary_ownCapital
	{
		public AccountSummary_ownCapital()
		{
		}
		[DataMember(EmitDefaultValue = false, Name = "$")]
		public double ownCapital { get; set; }
		[DataMember(EmitDefaultValue = false)]
		public string curr { get; set; }
	}
