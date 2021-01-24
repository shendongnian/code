	public class ResponseContainer<TContent>
	{
		public Response<TContent> Response { get; set; }
	}
	public class Response<TContent>
	{
		public int StatusCode { get; set; }
		public string StatusMessage { get; set; }
		public TContent Content { get; set; }
	}
