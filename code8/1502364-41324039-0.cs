    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        //find the button in the datalist item object and cast it back to one
        Button button = e.Item.FindControl("Button1") as Button;
    
        //you can now access it's properties
        button.BackColor = Color.Red;
    }
