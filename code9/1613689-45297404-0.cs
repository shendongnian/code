	public class CustomResult : IHttpActionResult
	{
		private readonly IHttpActionResult _decorated;
		private readonly Action<HttpResponseMessage> _response;
		public CustomResult(IHttpActionResult decorated, Action<HttpResponseMessage> response)
		{
			_decorated = decorated;
			_response = response;
		}
		public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
		{
			var response = await _decorated.ExecuteAsync(cancellationToken);
			_response(response);
			return response;
		}
	}
