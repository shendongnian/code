    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" Visible="False" />
                <asp:BoundField DataField="Class" HeaderText="Class" /> 
                <asp:BoundField DataField="Day" HeaderText="Day" />
                <asp:BoundField DataField="Time" HeaderText="Time" />
                <asp:BoundField DataField="Vacants" HeaderText="Vacants" />          
                <asp:ButtonField ButtonType="Button" HeaderText="Book" Text="Book"/>
            </Columns>
     </asp:GridView>
    
    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get your button via the column index; ideally you could use template field and put your own button inside
            var button = e.Row.Cell[5].Controls[0] as Button;
            int vacant = 0;
            var vacantVal = int.TryParse(e.Row.Cell[4].Text, out vacant);
            if (button != null)
            {
                button.Enabled = vacant > 0;
            }
        }
    }
