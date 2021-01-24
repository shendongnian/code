    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "addRow")
        {   
            doDataTable("add", e.Item.ItemIndex);
        }
        if (e.CommandName == "delRows")
        {   
            doDataTable("del", e.Item.ItemIndex);
        }
    }
