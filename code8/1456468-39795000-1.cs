    SqlConnection Conn = new SqlConnection(YOURCONNECTION);
    SqlCommand ExecuteJob = new SqlCommand();
    ExecuteJob.CommandType = CommandType.StoredProcedure;
    ExecuteJob.CommandText = "msdb.dbo.sp_start_job";
    ExecuteJob.Parameters.AddWithValue("@job_name", YOURJOBNAME")
    ExecuteJob.Connection = Conn; 
    using (Conn)
    {
        Conn.Open();
        using (ExecuteJob)
        {
            ExecuteJob.ExecuteNonQuery();
        }
    }
