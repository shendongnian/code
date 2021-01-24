    protected void Repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Image imgStamp = Repeater.Controls[0].Controls[0].FindControl("imgStamp") as Image;
        imgStamp.ImageUrl = Page.ResolveUrl("URL");
    }
