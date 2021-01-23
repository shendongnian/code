        public override async Task Invoke(IOwinContext context)
		{
			await Next.Invoke(context);
			var exception = HttpContext.Current.Items["exception"] as Exception;
			if (exception != null)
			{
				throw exception;
			}
		}
