    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e) 
        {
           if (e.Item.ItemType == ListItemType.Item)
            {
                Label lbl = e.Item.FindControl("lblDeposit") as Label;
                lbl.Text = "You Manual String Value";
            }
        }
