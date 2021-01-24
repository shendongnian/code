    protected void Page_Load(object sender, EventArgs e)
    {
	    if(!IsPostBack) // Add this If condition
	    {
	        SqlConnection con = new SqlConnection(
	        WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString);
	        con.Open();
	        SqlCommand cmd = new SqlCommand("Select UserRoleID, RoleType from tb_UserRoles", con);
	        DropDownList1.DataSource = cmd.ExecuteReader();
	        DropDownList1.DataTextField = "RoleType";
	        DropDownList1.DataValueField = "UserRoleID";
	        DropDownList1.DataBind();
	    }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(
        WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_UserInsertUpdate", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        String ID = DropDownList1.SelectedValue;
        cmd.Parameters.AddWithValue("UserID", (hfUserID.Value == "" ? 0 : Convert.ToInt32(hfUserID.Value)));
        cmd.Parameters.AddWithValue("UserRoleID", ID);
        cmd.Parameters.AddWithValue("Username", TextBox1.Text);
        cmd.Parameters.AddWithValue("Password", TextBox2.Text);
        cmd.Parameters.AddWithValue("Email", TextBox3.Text);
        cmd.Parameters.AddWithValue("DateCreate", TextBox4.Text);
        cmd.ExecuteNonQuery();
        con.Close();
    }
