    protected void Rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {    
           HyperLink  hplUrl = (HyperLink)e.Item.FindControl("Url");
           hplUrl.NavigateUrl = 'https://stackoverflow.com'; 
        }
    }
