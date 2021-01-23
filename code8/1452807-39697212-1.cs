	public class GlobalExceptionLogger : System.Web.Http.ExceptionHandling.ExceptionLogger
	{
		public override void Log(ExceptionLoggerContext context)
		{
			LogMessage logMsg = new LogMessage();
			logMsg.ID = System.Guid.NewGuid().ToString();
			logMsg.MessageType = MessageType.ResourceServerAPI;
			logMsg.SenderMethod = context.Request.RequestUri != null ? string.Format("Request URL: {0}", context.Request.RequestUri.ToString()) : "";
			logMsg.Level = MesageLevel.Error;
			logMsg.MachineName = Environment.MachineName;
			logMsg.Message = context.Exception.Message;
            // Set the ID
			context.Request.SetLogId(logMsg.ID);
			Logger.LogError(logMsg);
		}
	}
	public class GlobalExceptionHandler : System.Web.Http.ExceptionHandling.ExceptionHandler
	{
		public override void Handle(ExceptionHandlerContext context)
		{
            // Get the ID
			var id = context.Request.GetLogId();
			var metadata = new ErrorData
			{
				Message = "An error occurred! Please use the ticket ID to contact our support",
				DateTime = DateTime.Now,
				RequestUri = context.Request.RequestUri,
				ErrorId = id
			};
			var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, metadata);
			context.Result = new ResponseMessageResult(response);
		}
	}
