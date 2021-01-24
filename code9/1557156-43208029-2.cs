	protected void Application_EndRequest(object sender, EventArgs e) {
		if (Response.StatusCode != 401 || !Request.Url.ToString().Contains("Login/Windows")) return;
		//If Windows authentication failed, inject the forms login page as the response content
		Response.ClearContent();
		var r = new ViewRenderer();
		Response.Write(r.RenderViewToString("~/Views/Login/Login.cshtml"));
	}
