    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="OnSelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Country" HeaderText="Country"/>
        </Columns>
    </asp:GridView>
    <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
----------
    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        // do some business and redirect
    }
