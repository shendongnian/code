    foreach (RepeaterItem item in Repeater1.Items)
    {
       // Check for data item or alternating item
       if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
       {
           // find your radiobutton from repeater's item
           RadioButton RadioButton1 = item.FindControl("RadioButton1") as RadioButton;
            
           RadioButton1.Text = dr.GetString(5);
           //.. some other code
       }
    }
