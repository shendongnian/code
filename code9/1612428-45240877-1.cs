    using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnStringName"].ToString()))
    using (SqlCommand mySqlCommand = new SqlCommand())
    {
        try
        {
            conn.Open();
            mySqlCommand.Connection = conn;
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            mySqlCommand.CommandText = "getCities";
            mySqlCommand.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ConnectionTimeout"].ToString());
            mySqlCommand.Parameters.Add("@param", SqlDbType.VarChar).Value = param;     
            da.SelectCommand = mySqlCommand;
            da.Fill(ds, "cities");
        }
        catch (Exception ex)
        {            
          // LOG HERE the errors    
        }
    } // end using  
