	public class NewAssignment
	{
		[JsonProperty("@odata.type")]
		public string ODataType { get; set; }
		[JsonProperty("orderHint")]
		public string OrderHint { get; set; }
		public NewAssignment()
		{
			ODataType = "#microsoft.graph.plannerAssignment";
			OrderHint = " !";
		}
	}
