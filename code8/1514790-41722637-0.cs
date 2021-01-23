     //'places the call to the system and returns the data as a datatable
        public  DataTable GetDataAsDatatable(List<SqlParameter> sqlParameters, string connStr, string storedProcName)
        {
            var dt = new DataTable();
            var sqlCmd = new SqlCommand();
            using (var sqlconn = new SqlConnection(connStr))
            {
                sqlCmd.Connection = sqlconn;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = storedProcName;
                sqlCmd.CommandTimeout = 5000;
                foreach (var sqlParam in sqlParameters)
                {
                    sqlCmd.Parameters.Add(sqlParam);
                }
                using (var sqlDa = new SqlDataAdapter(sqlCmd))
                {
                    sqlDa.Fill(dt);
                }
            }
            sqlParameters.Clear();
            return dt;
        }
        //'places the call to the system and returns the data as a datatable
        public  DataTable GetDataAsDatatable(string connStr, string query)
        {
            var dt = new DataTable();
            var sqlCmd = new SqlCommand();
            using (var sqlconn = new SqlConnection(connStr))
            {
                sqlCmd.Connection = sqlconn;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = query;
                sqlCmd.CommandTimeout = 5000;
                using (var sqlDa = new SqlDataAdapter(sqlCmd))
                {
                    sqlDa.Fill(dt);
                }
            }
            return dt;
        }
