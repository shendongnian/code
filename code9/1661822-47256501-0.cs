        <form id="form1" runat="server">
        <asp:Repeater runat="server" ID="rptrInfo" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="rptrInfo_ItemDataBound">
            <ItemTemplate>
                <asp:Image ID="imgImage" runat="server" ImageUrl='<%#Eval("ImageUrl") %>' />
                <asp:Panel id="pnlVideo" runat="server">
                <video controls height="200" width="385" id="v<%#Eval("Info_Id") %>">
                    <source src="<%#Eval("VideoUrl") %>" type="video/mp4" />
                </video>
                </asp:Panel>
            </ItemTemplate>
        </asp:Repeater>
    </form>
    
        protected void rptrInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Image img = (Image)e.Item.FindControl("imgImage");
                    Panel pnlVdo = (Panel)e.Item.FindControl("pnlVideo");
    
                    if(DataBinder.Eval(e.Item.DataItem, "ImageURL") != null)
                    {
                       img.Visible = true;
                       pnlVdo.Visible = false;
                    }
                    else
                    {
                       img.Visible = false;
                       pnlVdo.Visible = true;
                    }
                }
    
            }
