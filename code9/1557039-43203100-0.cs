    using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn))
    {
        sqlConn.Open();
        sqlCmd.ExecuteNonQuery();
        bulkImport.WriteToServer(dataReader);
    }
