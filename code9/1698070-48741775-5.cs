    <asp:DataGrid id="dgLotDetails" runat="server" AutoGenerateColumns="false" DataKeyNames="ItemNumber" OnRowDataBound="GridViewMain_RowDataBound">
        <Columns>
            <asp:BoundColumn DataField="ItemNumber" SortExpression="ItemNumber" ReadOnly="True" HeaderText="ItemNumber"></asp:BoundColumn>
            <asp:BoundColumn DataField="ItemDescription" SortExpression="ItemDescription" ReadOnly="True" HeaderText="ItemDesc" Visible="False"></asp:BoundColumn>
            <asp:BoundColumn DataField="whse" SortExpression="whse" ReadOnly="True" HeaderText="Warehouse"></asp:BoundColumn>
            <asp:BoundColumn DataField="Bundle" SortExpression="Bundle" ReadOnly="True" HeaderText="Bundle"></asp:BoundColumn>
            <asp:TemplateColumn>
                <ItemTemplate>
                    <asp:DataGrid ID="dgLotDetailsExpand" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundColumn DataField="Size" SortExpression="Size" ReadOnly="True" HeaderText="Size"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Weight" SortExpression="Weight" ReadOnly="True" HeaderText="Weight"></asp:BoundColumn>
                        </Columns>
                    </asp:DataGrid>
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
