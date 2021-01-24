    <asp:ListView ... OnItemCommand="lv_MessageSubject_ItemCommand"
    ...
    <asp:Button ID="cmd_View" runat="server" CommandName="Highlight"
    ...
    protected void lv_MessageSubject_ItemCommand(Object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Highlight")
        {
            var ctrl = (HtmlContainerControl)e.Item.FindControl("area");
            ctrl.Attributes["style"] = "background-color:Navy; color:White; padding:0px;";
        }
    }
