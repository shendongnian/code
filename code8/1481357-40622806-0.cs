	StringWriter sw = new StringWriter();
	// Put HtmlTextWriter in using block because it needs to call Dispose.
	using (HtmlTextWriter writer = new HtmlTextWriter(sw))
	{
		writer.AddAttribute(HtmlTextWriterAttribute.Href, "http://stackoverflow.com");
		writer.RenderBeginTag(HtmlTextWriterTag.A); 
		writer.Write("Here's the coolest site ever.");
		writer.RenderEndTag(); 
	}
	
