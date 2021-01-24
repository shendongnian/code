	public class HandleExceptionsFilter : ExceptionFilterAttribute
	{
		public override void OnException(HttpActionExecutedContext context)
		{
			if (context.Exception is QueryFormatException)
			{
				context.Response = context.Request.CreateErrorResponse(HttpStatusCode.BadRequest, context.Exception.Message);
				return;
			}
			System.Diagnostics.Debug.WriteLine(context.Exception);
			context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
		}
	}
