    <asp:CheckBox ID="AApBlue" runat="server" />
    <asp:Label ID="Label1" Text='<% # Eval("blueFlag") %>' Visible="false" runat="server" >
    </asp:Label>
    .CS File:
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || 
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            CheckBox chk = e.Item.FindControl("AApBlue") as CheckBox;
            Label lbl = e.Item.FindControl("Label1") as Label;
            chk.Checked = (lbl.Text == "Y") ? true : false;
        }
    }
