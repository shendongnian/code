          /// <method>
        /// Select Query
        /// </method>
        public DataTable executeSelectQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;//or proc
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
                dataTable = ds.Tables[0];//as per your requirement
            }
            catch (SqlException e)
            {//any logger 
                Console.Write("Error - Connection.executeSelectQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return null;
            }            
                return dataTable;
        }
