    StringBuilder sbText = new StringBuilder();
    // Items collection
    foreach (ListItem item in lstPTLNameDHOD.Items)
    {
       if (item.Selected)
       {
           lbl1stPTL.Text = sbText.Append(item.Value.ToString()).ToString();
       }
    }
