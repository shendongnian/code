    <asp:TemplateField SortExpression="Status">
        <HeaderTemplate>
            <asp:LinkButton ID="lnkSort" runat="server" Text="Status" CommandName="Sort" CommandArgument="Status" />
        </HeaderTemplate>
    </asp:TemplateField>
    protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Sort"))
        {
            FilterExpression = e.CommandArgument.ToString() + " LIKE '%" + txtCaseNumber.Text + "%'";
            BindGridView();
        }
    }
