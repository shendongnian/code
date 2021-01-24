    protected void gotoanswerpage1(object sender, EventArgs e)
    {
        LinkButton link = (LinkButton)sender;
        string title = link.CommandArgument;
    
        Response.Redirect(string.Format("~/article/article.aspx?title={0}",Server.UrlEncode(title)), false);  
    }
