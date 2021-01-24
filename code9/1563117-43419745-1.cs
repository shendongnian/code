    protected void Delete(Object Sender, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button clickedDeleteButton= (Button)e.Item.FindControl("btnDelete"); 
                int idSub = int.Parse(clickedDeleteButton.Attributes["IDSub"]);
                // Here Delete codes by id...
