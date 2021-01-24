	namespace SomeWebApi
	{
		public class GlobalExceptionHandler : ExceptionHandler
		{
			public override async Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
			{
				if (context.Exception != null)
				{
					Exception filteredException = context.Exception;
					while (
						(filteredException != null)
						&&
						(filteredException.GetType() != typeof(HttpResponseException)
					)
					{
						filteredException = filteredException.InnerException ;
					}
					if (
						(filteredException != null)
						&&
						(filteredException != context.Exception)
					)
					{
						var httpResponseException = (HttpResponseException) filteredException;
						var response = context.Request.CreateErrorResponse(
							httpResponseException.Response.StatusCode,
							httpResponseException
						);
						context.Result = new ResponseMessageResult(response);
					}
				}
			}
		}
	}
