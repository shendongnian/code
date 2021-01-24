    protected void Page_Load(object sender, EventArgs e)
    {
       if(!IsPostBack) //Added
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
