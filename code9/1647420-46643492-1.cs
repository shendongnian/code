    protected void Application_Error(object sender, EventArgs e)
    {
    	Exception exception = Server.GetLastError();
    	Server.ClearError();
    
    	Logging.LogError(exception);
     	//Get a HTML file stored in resources which contains my error text and some tokens to replace.
    	dynamic html = My.Resources.ErrorText;
    	html = html.Replace("{Title}", Server.HtmlEncode(My.Application.Info.Title));
    	html = html.Replace("{Product}", Server.HtmlEncode(My.Application.Info.ProductName));
    	html = html.Replace("{Version}", Server.HtmlEncode(My.Application.Info.Version.ToString));
    
    	//Build my exception message looping though all the inner exceptions
    	dynamic errorDetails = exception.Message + Constants.vbNewLine + exception.StackTrace;
    
    	while (exception.InnerException != null) {
    		exception = exception.InnerException;
    		errorDetails += Constants.vbNewLine + Constants.vbNewLine + "Inner Exception: " + Constants.vbNewLine + exception.Message + Constants.vbNewLine + exception.StackTrace;
    	}
    
        //Replace the {ErrorDetails} tag with my error text
    	html = html.Replace("{ErrorDetails}", Server.HtmlEncode(errorDetails).Replace(Constants.vbNewLine, "<br/>"));
    
        //Replace the logo tag
    	using (IO.MemoryStream ms = new IO.MemoryStream()) {
    		using (img == My.Resources.Logo) {
    			img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
    			dynamic logoBytes = ms.ToArray;
    			html = html.Replace("{Logo}", "data:image/png;base64," + Convert.ToBase64String(logoBytes, 0, logoBytes.Length));
    		}
    	}
    
        //Replace the response
    	Response.Clear();
    	Response.Write(html);
    	Response.Flush();
    }
