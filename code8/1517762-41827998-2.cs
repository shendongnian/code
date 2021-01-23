    <asp:GridView ID="GridView1" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Page    
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("page") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField>
                    <HeaderTemplate>
                        Navigation    
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdn_navigation" Value='<%# Bind("navigation") %>' runat="server" />
                        <asp:LinkButton ID="LinkButton1" CommandName="navigation" runat="server">Click Me</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
