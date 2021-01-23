        protected void Application_Error(object sender, EventArgs e)
		{
			var lastException = Server.GetLastError();
			if (lastException != null)
			{
				HttpContext.Current.GetOwinContext().Set("lastException", lastException);
			}
		}
