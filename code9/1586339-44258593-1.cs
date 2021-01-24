    using (SqlConnection connection = new SqlConnection(connectionstring))
    {
        string query = "SELECT TOP (1) [ZVNr] ZVNR_TABLE WHERE [ZVNr] = @zvnr order by [ZVNr] DESC";
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@zvnr", "20170530-01");
            connection.Open();
            object dbresult = cmd.ExecuteScalar();
            if (dbresult != DBNull.Value)
            {
                string result = (string)dbresult;
            }
        }
    }
      
