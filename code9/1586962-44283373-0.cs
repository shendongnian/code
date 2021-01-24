	public class OkWithLocation<T> : IHttpActionResult
	{
		private readonly CreatedAtRouteNegotiatedContentResult<T> _result;
		public OkWithLocation(CreatedAtRouteNegotiatedContentResult<T> result)
		{
			_result = result;
		}
		public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
		{
			var response = await _result.ExecuteAsync(cancellationToken).ConfigureAwait(false);
			response.StatusCode = HttpStatusCode.OK;
			return response;
		}
	}
