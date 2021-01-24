    <asp:Repeater ID="rptTest" runat="server" OnItemDataBound="rptTest_ItemDataBound">
        <ItemTemplate>
            <asp:CheckBoxList ID="ChkBoxList" runat="server">
            </asp:CheckBoxList>
        </ItemTemplate>
    </asp:Repeater>
    protected void rptTest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListItemType.AlternatingItem) || e.Item.ItemType.Equals(ListItemType.Item))
            {
                CheckBoxList cboxlist = e.Item.FindControl("chChkBoxListk") as CheckBoxList;
    
                cboxlist.DataSource = "Datasource for checkbox list (datatable, object list and so on..)";
                cboxlist.DataTextField = "TextDisplayField";
                cboxlist.DataValueField = "ValueField";
                cboxlist.DataBind();
            }
        }
