    public void saveReport(IEnumerable<ReportTrafficDepartment> report)
    {
        SqlTransaction tr = null;
        try
        {
            using(SqlConnection conn = new SqlConnection("connetcion string"))
            {
                conn.Open();
                tr = conn.BeginTransaction();
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
                   tr.Dispose();
                }
            }
        }
        catch
        {
            // If something goes wrong rollback every inserted executed
            if(tr != null) 
            {
               tr.RollBack();
               tr.Dispose();
            }
            // ------
            // Here you should log the error before throwing. 
            // It is a good habit and often a lifesaver to log the errors 
            // ------
            throw;
        }
    }
