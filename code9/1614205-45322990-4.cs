        private List<string> GetEmailPerDepartmentGroup(int DepartmentId)
        {
            List<string> result = new List<string>();
            myConnectionString = ConfigurationManager.ConnectionStrings["FSK_ServiceMonitor_Users_Management.Properties.Settings.FSK_ServiceMonitorConnectionString"].ConnectionString;
            using (mySQLConnection = new SqlConnection(myConnectionString))
            {
                mySQLCommand = new SqlCommand("spMapUsersToDepartments", mySQLConnection);
                mySQLCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@DepartmentId", DepartmentId);
                mySQLCommand.Parameters.Add(parameter);
                mySQLConnection.Open();
                mySQLDataReader = mySQLCommand.ExecuteReader();
                while (mySQLDataReader.Read())
                {
                    result.Add(mySQLDataReader["email"].ToString());
                }
            }
            return result;
        }
