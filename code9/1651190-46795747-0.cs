    <asp:CheckBox ID="AApBlue" Text='<% # Eval("blueFlag") %>' runat="server" />
    .cs file
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || 
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            CheckBox chk = e.Item.FindControl("AApBlue") as CheckBox;
            chk.Checked = (chk.Text == "Y") ? true : false;
        }
    }
