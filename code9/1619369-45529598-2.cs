    using (var sqlconn = new SqlConnection(sqlconnectionstring))
    {
        using (var Insertcmd = new SqlCommand("stp_AUStagAPITestData_Insert", sqlconn))
        {
            //  Create the data table
            using (var dt = new DataTable())
            {
                dt.Columns.Add("TestSuite", typeof(int));
                dt.Columns.Add("TestCase", typeof(int));
                dt.Columns.Add("Status", typeof(int));
                dt.Columns.Add("Info", typeof(string));
                dt.Columns.Add("Time", typeof(DateTime));
                dt.Columns.Add("IsArchived", typeof(bool));
                dt.Columns.Add("DateTime", typeof(DateTime));
                // Populate the data table from the TDData string array
                for (int j = 1; j < TDData.Length; j += 5)
                {
                    dt.Rows.Add
                    (
                        TDData[j],      // TestSuite
                        TDData[j + 1],  // TestCase
                        TDData[j + 2],  // Status
                        TDData[j + 3],  // Info
                        TDData[j + 4],  // Time
                        true,           // IsArchived
                        DateTime.Now    // DateTime
                    );
                }
                
                Insertcmd.CommandType = CommandType.StoredProcedure;
                Insertcmd.Parameters.Add("@Data", SqlDbType.Structured).Value = dt;
                try
                {
                    sqlconn.Open();
                    Insertcmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    // Exception handling code goes here...
                }
            }
        }
    }
