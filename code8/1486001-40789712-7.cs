    public class RethrowExceptionsMiddleware : OwinMiddleware
	{
		public RethrowExceptionsMiddleware(OwinMiddleware next) : base(next)
		{
		}
		public override async Task Invoke(IOwinContext context)
		{
			await Next.Invoke(context);
			var exception = context.Get<Exception>("lastException");
			if (exception != null)
			{
				var info = ExceptionDispatchInfo.Capture(exception);
				info.Throw();
			}
		}
	}
