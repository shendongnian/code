    <asp:GridView runat="server" ID="BookGridView" AutoGenerateColumns="False"
        ItemType="DemoWebForm.Book">
        <Columns>
            <asp:BoundField DataField="Author" HeaderText="Author" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="OpenBookLinkButton" Text="Open Book" 
                        OnCommand="Load_Book" CommandArgument="<%#: Item.Id %>">
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
