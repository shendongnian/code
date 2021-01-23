    protected void Btn_Click(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "BtnClick"){
            e.ToString();
        }
    }
    <asp:Repeater ID="rptImage" runat="server">
          <ItemTemplate>
              <asp:Button id="btnDelete" runat="server" Text="DELETE"  OnCommand="Btn_Click" CommandName="Btn_Click" CommandArgument='<%# Eval() %>'  />
              <asp:Image ID="image" runat="server"  ImageUrl='<%# Container.DataItem %>' />
          </ItemTemplate>
    </asp:Repeater>
