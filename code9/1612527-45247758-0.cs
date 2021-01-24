	public static class RequestTypeConst
	{
		public const Query = "Query";
	}
	class Handler
	{
		protected IRequest Request { get; set; }
		public Handler(IRequest request) 
		{ 
			Request = request;
		}
		public void HandleRequest(string requestType)
		{
			if (requestType == RequestTypeConst.Query)
			{
				Request.Query();
			}
		}
	}
	interface IRequest
	{
		List<string> Query();
	}
	class Request : IRequest
	{
		public List<string> Query()
		{
			/** do something **/
			return new List<string>();
		}
	}
	var handler = new Handler(new Request());
	hanlder.HandleRequest("Query");
