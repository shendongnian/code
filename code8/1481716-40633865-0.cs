            string jrs = "";
            string dateofBirth = "";
            string connectionString = ConfigurationManager.ConnectionStrings["TGSDataConnection"].ConnectionString;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string query = "SELECT * from LIMS_SAMPLE_RESULTS_VW where JRS_NO =:jrs and DOB=:dateofBirth";
                OracleCommand command = new OracleCommand(query, connection);
                command.Parameters.Add(new OracleParameter("jrs", jrs));
                command.Parameters.Add(new OracleParameter("dateofBirth", dateofBirth));
                command.CommandType = CommandType.Text;
                connection.Open();
                OracleDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        string value = reader["ColumName"].ToString();
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
