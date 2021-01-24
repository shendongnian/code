    protected void Application_Error(object sender, EventArgs e)
    {
    	Exception exception = Server.GetLastError();
    	Server.ClearError();
    
    	Logging.LogError(exception);
    
    	dynamic html = My.Resources.ErrorText;
    	html = html.Replace("{Title}", Server.HtmlEncode(My.Application.Info.Title));
    	html = html.Replace("{Product}", Server.HtmlEncode(My.Application.Info.ProductName));
    	html = html.Replace("{Version}", Server.HtmlEncode(My.Application.Info.Version.ToString));
    
    	dynamic errorDetails = exception.Message + Constants.vbNewLine + exception.StackTrace;
    
    	while (exception.InnerException != null) {
    		exception = exception.InnerException;
    		errorDetails += Constants.vbNewLine + Constants.vbNewLine + "Inner Exception: " + Constants.vbNewLine + exception.Message + Constants.vbNewLine + exception.StackTrace;
    	}
    
    	html = html.Replace("{ErrorDetails}", Server.HtmlEncode(errorDetails).Replace(Constants.vbNewLine, "<br/>"));
    
    	using (IO.MemoryStream ms = new IO.MemoryStream()) {
    		using (img == My.Resources.Logo) {
    			img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
    			dynamic logoBytes = ms.ToArray;
    			html = html.Replace("{Logo}", "data:image/png;base64," + Convert.ToBase64String(logoBytes, 0, logoBytes.Length));
    		}
    	}
    
    
    	Response.Clear();
    	Response.Write(html);
    	Response.Flush();
    }
