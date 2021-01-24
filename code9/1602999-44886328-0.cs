            public List<int> getSubGroupsBelongingToUser()
            {
                List<int> DepartmentSubGroupIds = new List<int>();
    
                myConnectionString = ConfigurationManager.ConnectionStrings["FSK_ServiceMonitor_Users_Management.Properties.Settings.FSK_ServiceMonitorConnectionString"].ConnectionString;
                using (mySQLConnection = new SqlConnection(myConnectionString))
                {
                    SqlParameter parameter = new SqlParameter("@UserId", getUserID(cbxSelectUser.Text));
                    mySQLCommand = new SqlCommand("Test", mySQLConnection);
                    mySQLCommand.CommandType = CommandType.StoredProcedure;
                    mySQLCommand.Parameters.Add(parameter);
                    mySQLConnection.ConnectionString = myConnectionString;
                    mySQLConnection.Open();
    
                    SqlDataReader sqlDataReader = mySQLCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        DepartmentSubGroupIds.Add(Convert.ToInt32(sqlDataReader["DepartmentSubGroupId"]));
                    }
                }
                return DepartmentSubGroupIds;
            }
