    public void jobCardNewTable(SqlConnection connection)
    {
            string sc3 = "";
            sc3 = @"INSERT INTO job1 (" + pv.jobstring + ") VALUES (" + pv.jobparam + ")";
            SqlCommand cmd = new SqlCommand(sc3, connection);
            queryParams(cmd, 0);
            cmd.ExecuteNonQuery();
       
    }
