    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || 
                 e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string FId = (e.Item.FindControl("FID") as Label).Text;
            GridView GridView1 = e.Item.FindControl("GridView1") as GridView;
            // select data from parent Table
            GridView1.DataSource = 
                    GetData(string.Format("select * from ParentTable where FId='{0}'", FId));
            GridView1.DataBind();
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // get repeater item where clicked
        RepeaterItem item = ((GridView)sender).Parent as RepeaterItem;
        string FId = ((Label)Repeater1.Items[item.ItemIndex].FindControl("FID")).Text;
        // get gridview from Repeater
        GridView GridView1 = (sender as GridView);
        GridView1.PageIndex = e.NewPageIndex;
        // select data from child table
        GridView1.DataSource = 
                GetData(string.Format("select * from ChildTable where FId='{0}'", FId));
        GridView1.DataBind();
    }
