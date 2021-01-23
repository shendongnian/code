    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField Visible="false" DataField="id" />
                <asp:TemplateField HeaderText="Has Attachment">
                    <ItemTemplate>
                        <asp:Label ID="lblAtt" runat="server" Text='<%#Eval("HasAtt") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="View Attachment">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnAtt" runat="server" OnClick="lbtnAtt_Click" Visible="false">View</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
