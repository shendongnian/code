    <asp:TextBox ID="archiveJobNumber" runat="server" AutoPostBack="True"
        OnTextChanged="archiveJobNumber_TextChanged" />
    
    <asp:DropDownList ID="archiveCustomer" runat="server"
        DataTextField="Name" DataValueField="CustID" AutoPostBack="True">
    </asp:DropDownList>
    
    
    protected void archiveJobNumber_TextChanged(object sender, EventArgs e)
    {
        var query = "SELECT CustID, Name FROM Users WHERE CustID= @Id";
        using (var con = new SqlConnection(connectionString))
        using (var da = new SqlDataAdapter(query, con))
        {
            con.Open();
            var dt = new DataTable();
            da.SelectCommand.Parameters.AddWithValue("@Id", archiveJobNumber.Text);
    
            da.Fill(dt);
            archiveCustomer.DataSource = dt;
            archiveCustomer.DataBind();
        }
    }
