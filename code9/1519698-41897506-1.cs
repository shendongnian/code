    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //use findcontrol to find the panel and cast it as one
        Panel panel = e.Item.FindControl("PanelTilbud") as Panel;
        //get the current datarowview
        DataRowView row = e.Item.DataItem as DataRowView;
        //check the value and change the panel visibility
        if (row["Maskine_Type"].ToString() == "myValue")
        {
            panel.Visible = true;
        }
    }
