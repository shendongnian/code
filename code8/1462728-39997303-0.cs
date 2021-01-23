    protected void repImages_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Image img = (Image)e.Item.FindControl("Image1");
        if (img != null)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                DataRowView row = e.Item.DataItem as DataRowView;
                byte[] data = (byte[])row["ImageData"]; // get your data from the row
      
                img.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(data); 
             }
        }
    }
