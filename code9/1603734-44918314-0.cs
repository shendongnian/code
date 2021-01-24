            DataSet dataset = new DataSet();
            using (OracleConnection connection = new OracleConnection(connection))
            {
                using (OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(new OracleCommand(query, connection)))
                {
                    oracleDataAdapter.SelectCommand.CommandTimeout = 30;
                    connection.Open();
                    oracleDataAdapter.Fill(dataset, table);
                }
            }
            return dataset;
