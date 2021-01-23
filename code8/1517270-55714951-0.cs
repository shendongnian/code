    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" ViewStateMode="Enabled">
                <asp:ListItem>Select College</asp:ListItem> <!--Add one item as title into dropdownlist in edit item of dropdownlist-->
            </asp:DropDownList>
 
protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.Write("hello");
                try
                {
                    string sel = "select name from websites";
                    SqlCommand cmd = new SqlCommand(sel,con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                   /* DropDownList1.DataSource = dr;
                    DropDownList1.DataTextField = "name";
                    DropDownList1.DataValueField = "name";
                    DropDownList1.DataBind();*/
                    while (dr.Read())//used dr.read() instead of datasource
                    {
                        DropDownList1.Items.Add(dr["name"].ToString());
                    }
                }
                catch(Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select url from websites where name = @itm", con);
                cmd.Parameters.AddWithValue("@itm", DropDownList1.SelectedItem.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    Response.Redirect(dr["url"].ToString());
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
