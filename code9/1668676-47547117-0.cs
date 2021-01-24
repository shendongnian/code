     protected DataTable findCourse()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select descr from restrnt_master", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            con.Close();
           
            return dt;
        }
    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSource="<%# findCourse() %>"
                                            SelectedValue='<%# Eval("item") %>'
                                            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
    <FooterTemplate>
                                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataSource="<%# findCourse() %>" 
                                            onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <br />
                                    </FooterTemplate>
