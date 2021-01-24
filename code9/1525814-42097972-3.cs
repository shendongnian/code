    SqlParameter outParam = new SqlParameter("CustomerID", 0);
    using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StringName"].ConnectionString))
    {
        using (SqlCommand cmd = new SqlCommand("InsertCustomer", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;				
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = CustomerName;
                        cmd.Parameters.Add(outParam.ParameterName, SqlDbType.BigInt).Direction = ParameterDirection.Output;					
            con.Open();
            var CustomerID = Convert.ToInt64(cmd.Parameters["CustomerID"].Value);
        }
    }
