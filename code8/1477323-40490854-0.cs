    //create your connection string
    string Conn = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
    using (SqlConnection connection = new SqlConnection(Conn))
    {
        //add your SP to the SqlCommand
        SqlCommand cmd = new SqlCommand("dbo.MyProcedure", connection);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter myParam = new SqlParameter("@YourParam", //Your SqlDbType);
        myParam.Value = //your value;
        cmd.Parameters.Add(myParam);
        //Add more parameters if applicable...
        SqlDataReader dr = command.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                //map to your custom object here by instantiating one and mapping 
                //the SqlDataReader columns to your custom object properties.
            }
        }
     }
