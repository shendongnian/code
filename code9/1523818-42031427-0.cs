	protected void Application_EndRequest(object sender, EventArgs e)
	{
		if (Response.StatusCode != 401)
			return;
		Response.ClearContent();
		Response.WriteFile("~/ui/Other/YouShallNotPass.html");
		Response.ContentType = "text/html";
	}
