public void UseMyMiddleware(IApplicationBuilder app)
{
	app.Use(async (context, next) =>
	{
		context.Request.EnableBuffering();
		using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, false, 1024, true))
		{
			var body = await reader.ReadToEndAsync();
						
			context.Request.Body.Seek(0, SeekOrigin.Begin);
		}
		await next.Invoke();
	});
}
