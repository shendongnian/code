    String strConnString = ConfigurationManager.ConnectionStrings["CallcenterConnectionString"].ConnectionString;
    var dt = new DataTable();
    using (var con = new SqlConnection(strConnString))
    {
        con.Open();
        using (var cmd = new SqlCommand("UserManagement", con))
        {
            cmd.Parameters.Add("@CallType", SqlDbType.VarChar).Value = ddlCalltype.SelectedValue.ToString();
            cmd.Parameters.Add("@Format", SqlDbType.VarChar).Value = ddlFormat.SelectedValue.ToString();
            cmd.Parameters.Add("@disposition", SqlDbType.VarChar).Value = ddlDisp.SelectedValue.ToString();
            cmd.Parameters.Add("@SubDisposition", SqlDbType.VarChar).Value = ddlSubdisp.SelectedValue.ToString();
            cmd.CommandType = CommandType.StoredProcedure;
            // using SqlDataAdapter
            using (var da = new SqlDataAdapter)
            {
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            // using DataTable.Load directly
            // dt.Load(cmd.ExecuteReader());
        }
        con.Close();
    }
    // other stuff
