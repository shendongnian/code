     SqlCommand cmd = new SqlCommand();
              SqlDataAdapter da=null;
              DataSet dsFormat = new DataSet();
    
             String strConnString = 
    ConfigurationManager.ConnectionStrings["CallcenterConnectionString"].ConnectionString;
    
             using (var con = new SqlConnection(strConnString))
              {
               con.Open();
    
               using (cmd = new SqlCommand("ROMA_UserManagement", con))
                 {
                   cmd.Parameters.Add("@flag", SqlDbType.VarChar).Value = "1";
                   cmd.Parameters.Add("@CallType", SqlDbType.VarChar).Value = ddlCalltype.SelectedValue.ToString();
                   cmd.Parameters.Add("@Format", SqlDbType.VarChar).Value ="";
                   cmd.Parameters.Add("@disposition", SqlDbType.VarChar).Value = "";
                   cmd.Parameters.Add("@SubDisposition", SqlDbType.VarChar).Value ="";
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.ExecuteNonQuery();
                   da=new SqlDataAdapter(cmd);
                   da.Fill(dsFormat);
                 }
                   con.Close();
           }
           ddlFormat.DataValueField = "DISPFORMAT";
           ddlFormat.DataTextField = "FORMATDETAIL";
           ddlFormat.DataSource = dsFormat.Tables[0];
           ddlFormat.DataBind();
           ddlFormat.Items.Insert(0, "<----Select---->");
 
