    public void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if(e.CommandName == "Selected")
        {
             Label lbl = e.item.FinControl("ActualTimeLabel") as Label;
             Label1.Text = "You selected: " + lbl.Text;
        }
    }
