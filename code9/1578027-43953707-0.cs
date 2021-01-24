	  string connString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            SqlCommand command = new SqlCommand("SP_GetCityByID", conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter param = command.Parameters.Add("@ID", SqlDbType.Int).Value = 2;
            //param.Direction = ParameterDirection.Input;
            command.ExecuteNonQuery();
            Console.WriteLine(param.Value);
        }
