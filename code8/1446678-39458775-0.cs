    List<DataElement> InputParams = new List<DataElement>();
    SqlConnection connect = new SqlConnection(<connection_string>);
    SqlCommand cmd = new SqlCommand("pUtil_GenDFAutomate", connect);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add(new SqlParameter("@TableName", <table_name>));
    using (var reader = cmd.ExecuteReader())
    {
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var name = reader.GetString(0);
                var type = reader.GetString(1);
                
                InputParams.Add(new DataElement
                {
                    Name = name,
                    Type = type
                });
            }
            reader.Close();
        }
    }
