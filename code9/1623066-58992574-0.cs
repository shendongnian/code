		private Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			if (!context.Response.HasStarted)
			{
				string result;
				
				context.Response.StatusCode = StatusCodes.Status500InternalServerError;
				result = JsonConvert.SerializeObject(new { error = "An error has occured" });
				_logger.LogError(ex, CreateErrorMessage(context));				
				context.Response.ContentType = "application/json";
				return context.Response.WriteAsync(result);
			}
			else
			{
				return context.Response.WriteAsync(string.Empty);
			}
		}
