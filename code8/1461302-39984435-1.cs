		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			if (Context.Request.Path.Contains("odata/"))
			{
				Context.Response.AddHeader("Access-Control-Allow-Origin", "*");
				Context.Response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
				Context.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST PUT, DELETE, OPTIONS");
				Context.Response.AddHeader("Access-Control-Allow-Credentials", "true");
			}
		}
