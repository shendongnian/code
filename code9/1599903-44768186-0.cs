    ...
 
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
            
            foreach (SqlParameter sqlParameter in sqlParameterCollection)
            {
                sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
            }
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
...
