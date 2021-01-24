	internal class ExecutionParametersJson
	{
		#region Properties
		public int SomeOtherProperty { get; set; }
		public string SomeProperty { get; set; }
		#endregion
		[JsonProperty("Factor")]
		public string Factor { get; set; }
		[JsonProperty("Penalty")]
		public string Penalty { get; set; }
		[JsonProperty("Origin")]
		public string Origin { get; set; }
		[JsonProperty("InterFactor")]
		public string InterFactor { get; set; }
	}
