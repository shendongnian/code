    <asp:GridView ID="DataGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="DataGridView_RowCommand">
            <Columns>
                <asp:BoundField NullDisplayText="N/A" />
                <asp:TemplateField>
                    <ItemTemplate>
                        &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" CommandName="yourCommandName">LinkButton</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
     protected void DataGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {      
                if (e.CommandName == "yourCommandName")
                  {
                    //Do something here
                  }
        }
