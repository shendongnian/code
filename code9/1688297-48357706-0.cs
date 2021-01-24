    app.Use(async (context, next) =>
			{
				if (context.Request.QueryString.HasValue)
				{
					if (string.IsNullOrWhiteSpace(context.Request.Headers.Get("Authorization")))
					{
						string token = context.Request.Query.Get("auth");
						if (!string.IsNullOrWhiteSpace(token))
						{
							context.Request.Headers.Add("Authorization", new[] { string.Format("Bearer {0}", token) });
						}
					}
				}
				await next.Invoke();
			});
