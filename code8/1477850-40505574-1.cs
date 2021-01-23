    protected void rptCustomers_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || 
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string fieldValue= (e.Item.FindControl("hfCustomerId") as HiddenField).Value;
            int customerId = int.Parse(fieldValue);
            Repeater rptOrders = e.Item.FindControl("rptOrders") as Repeater;
            rptOrders.DataSource = GetItemsById(customerId).ToList();
            rptOrders.DataBind();
        }
    }
    
