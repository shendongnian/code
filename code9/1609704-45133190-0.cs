    using(SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
    {
         connection.Open();
          
        string insertQ = "INSERT INTO login_tbl (empid,first_name,last_name,team_name,pwd,email_id,extension) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7)";
    
            SqlCommand cmd = new SqlCommand(sql,connection);
            cmd.Parameters.Add("@param1", SqlDbType.Int).value = empid;
            cmd.Parameters.Add("@param2", SqlDbType.Varchar, 50).value=first_name;
            cmd.Parameters.Add("@param3", SqlDbType.Varchar, 50).value=last_name;
            cmd.Parameters.Add("@param4", SqlDbType.Varchar, 50).value = team_name;
            cmd.Parameters.Add("@param5", SqlDbType.Varchar, 50).value = pwd;
            cmd.Parameters.Add("@param6", SqlDbType.Int).value = email_id;
            cmd.Parameters.Add("@param7", SqlDbType.Varchar, 50).value = extension;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
    }
    Response.Write("registration done");
