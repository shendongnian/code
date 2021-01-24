    protected void Repeater_weatherReports_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    RepeaterItem item = e.Item;
    if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
    {
    Label lblmin = (Label)item.FindControl("Label_min");
    Label lblmax = (Label)item.FindControl("Label_max");
    //.........and you can set of get values here.
    }
    }
