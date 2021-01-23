    protected void Btn_Click(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "BtnClick"){
            e.CommandArgument.ToString();
        }
    }
    <asp:Repeater ID="rptImage" runat="server">
          <ItemTemplate>
              <asp:Button id="btnDelete" runat="server" Text="DELETE"  OnCommand="Btn_Click" CommandName="Btn_Click" CommandArgument="<%# Container.DataItem %>"  />
              <asp:Image ID="image" runat="server"  ImageUrl="<%# Container.DataItem %>" />
          </ItemTemplate>
    </asp:Repeater>
