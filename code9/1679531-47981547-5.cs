    public void saveReport(IEnumerable<ReportTrafficDepartment> report)
    {
        try
        {
            using(SqlConnection conn = new SqlConnection("connetcion string"))
            {
                conn.Open();
                using(SqlTransaction tr = conn.BeginTransaction())
                using(SqlCommand cmd = new SqlCommand("SaveEcxelReport", conn, tr)
                {
                     cmd.CommandType = CommandType.StoredProcedure; 
                     cmd.Parameters.Add("@siteNum", SqlDbType.Int);
                     cmd.Parameters.Add("@dateReport", SqlDbType.DateTime);
                     .... other parameters ....
                    foreach (var record in report)
                    {
                        cmd.Parameters["@siteNum"].Value = record.siteNum;
                        cmd.Parameters["@dateReport"].Value = record.dateReport;
                        ... set the values for other parameters
                        cmd.ExecuteNonQuery();
                   }
                   tr.Commit();
                }
            }
        }
        catch
        {
            // If something goes wrong the rollback is executed automatically 
            // when you exit from the using block above
            //if(tr != null) 
            //{
            //   tr.RollBack();
            //}
            // ------
            // Here you should log the error before throwing. 
            // It is a good habit and often a lifesaver to log the errors 
            // ------
            // But if you don't log or you don't do anything else 
            // but just throw then the whole try catch is useless 
            // and you can completely remove it 
            throw;
        }
    }
