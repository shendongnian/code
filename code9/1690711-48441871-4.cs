    protected void RptID_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //cast the item back to its class
        Options item = e.Item.DataItem as Options;
        //assign the new value to the global string
        previousValue = item.T;
    }
