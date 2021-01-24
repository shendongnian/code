     try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            
            List<OracleParameter> parametri = new List<OracleParameter>()
                    {
                        new OracleParameter
                        {
                            ParameterName = nameof(filter.PARAM_1),
                            Direction = ParameterDirection.Input,
                            OracleDbType = OracleDbType.NVarchar2,
                            Value = filter.PARAM_1
                        }
                    };
            
            OracleCommand cmd = conn.CreateCommand();
            cmd.Parameters.AddRange(parametri.ToArray());
            OracleParameter cursor = cmd.Parameters.Add(
                new OracleParameter
                {
                    ParameterName = "RESULT",
                    Direction = ParameterDirection.Output,
                    OracleDbType = OracleDbType.RefCursor
                }
            );
            cmd.CommandText = procedureName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            using (OracleDataReader reader = ((OracleRefCursor)cursor.Value).GetDataReader())
            {
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        //Iterate the result set
                    }
            }
    }
    catch(Exception ex)
    {
        //Manage exception
    }
       
