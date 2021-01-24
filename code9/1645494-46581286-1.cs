	public AiExceptionInitializer(IHttpContextAccessor httpContextAccessor)
	{
		this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException("httpContextAccessor");
	}
	public void Initialize(ITelemetry telemetry)
	{
		var context = this.httpContextAccessor.HttpContext;
		if (context == null)
		{
			return;
		}
		lock (context)
		{
			var request = context.Features.Get<RequestTelemetry>();
			if (request == null)
			{
				return;
			}
			this.OnInitializeTelemetry(context, request, telemetry);
		}
	}
	protected void OnInitializeTelemetry(HttpContext platformContext, RequestTelemetry requestTelemetry, ITelemetry telemetry)
	{
		if (telemetry is ExceptionTelemetry exceptionTelemetry)
		{
			var requestBody = platformContext.Items[ExceptionBodyTrackingMiddleware.ExceptionRequestBodyKey] as string;
			exceptionTelemetry.Properties.Add("HttpRequestBody", requestBody);
		}
	}
