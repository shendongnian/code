     public static void LoadDataSet(ref DataSet ds, string name, params object[] parameters)
        {
            SqlConnection con = new SqlConnection(connectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(name, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(da.SelectCommand);
            if (da.SelectCommand.Parameters.Count - 1 != parameters.Length)
            {
                return;
            }
            int i = 0;
            foreach (SqlParameter pr in da.SelectCommand.Parameters)
            {
                if (pr.Direction == ParameterDirection.Input || pr.Direction == ParameterDirection.InputOutput)
                {
                    pr.Value = parameters[i];
                    i++;
                }
            }
            da.Fill(ds);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
