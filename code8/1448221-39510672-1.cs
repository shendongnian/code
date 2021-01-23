    <asp:CheckBoxList ID="CheckBoxList1" runat="server" OnTextChanged="CheckBoxList1_TextChanged" AutoPostBack="true"></asp:CheckBoxList>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="field01" HeaderText="Column A" />
            <asp:BoundField DataField="field02" HeaderText="Column B" />
            <asp:BoundField DataField="field03" HeaderText="Column C" />
            <asp:BoundField DataField="field04" HeaderText="Column D" />
            <asp:BoundField DataField="field05" HeaderText="Column E" />
        </Columns>
    </asp:GridView>
