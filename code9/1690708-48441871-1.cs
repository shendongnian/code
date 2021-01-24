    public string previousValue = "";
    protected void RptID_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //cast the item back to a datarowview
        DataRowView item = e.Item.DataItem as DataRowView;
        //assign the new value to the global string
        previousValue = item["T"].ToString();
    }
