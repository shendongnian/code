    SqlConnection con; 
    SqlCommand cmd;
    SqlDataAdapter adr;
    DataTable dt;
    string conStr;
    
    conStr = ConfigurationManager.ConnectionStrings["payRollConnection"].ConnectionString;
    using(con = new SqlConnection(conStr)) {
            using(cmd = new SqlCommand("selectEmployeePayCheck", con)) {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fname", ddlEmployees.SelectedValue);
            // or cmd.Parameters.AddWithValue("@fname", ddlEmployees.SelectedText.ToString()); 
            // according to your query at the backend
            adr = new SqlAdapter(cmd);
            dt = new DataTable();
            adr.Fill(dt);
            }
        }
    ddlEmployees.DataSource = dt;
    ddlEmployees.DataTextField = "empFname";
    ddlEmployees.DataValueField = "empFname";
    ddlEmployees.DataBind();
    
