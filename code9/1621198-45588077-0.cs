	// pass in the row id in command argument
	<asp:Button ID="btnViewXML" class="btn btn-warning btn-xs" runat="server" 
						Text="View XML"  CommandArgument='<%= row.Id %>' OnCommand="ViewXML" />
						
	protected void ViewXML(object sender, CommandEventArgs e)
	{
		// id of row
		string id =e.CommandArgument.ToString();
		// fetch from db to get your xml content
		string xmlContent = ...;
		
		
		Response.Clear();
		Response.Buffer = true;
		Response.Charset = "";
		Response.Cache.SetCacheability(HttpCacheability.NoCache);
		Response.ContentType = "application/xml";
		Response.Write(xmlContent);
		Response.Flush();
		Response.End();
	}
	
