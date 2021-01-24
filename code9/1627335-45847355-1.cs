    public class Value
	{
		[JsonProperty("@odata.etag")]
		public string Etag { get; set; }
		public string ticketnumber { get; set; }
		public int statuscode { get; set; }
		public string incidentid { get; set; }
	}
	public class TicketStatus
	{
		[JsonProperty("@odata.context")]
		public string Context { get; set; }
		public List<Value> value { get; set; }
	}
