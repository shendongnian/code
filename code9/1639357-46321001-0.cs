	if (e.CommandName == "View")
	{
		int index = Convert.ToInt32(e.CommandArgument);
		string FileName = ((Label)gvwUserManual.Rows[index].FindControl("lblFileName")).Text;
		string XlsPath = Server.MapPath(@"~/SupportDocuments/" + Request.Cookies["BCookies"]["SessionUserName"].Trim().ToString() +"/" + FileName);
	
		// send file to user
		Response.Clear();
		Response.AppendHeader("content-disposition", "attachment; filename=" + FileName);
		Response.ContentType = "application/octet-stream";
		Response.WriteFile(XlsPath);
		Response.Flush();
		Response.End();
	}
