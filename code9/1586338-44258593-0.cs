    using (SqlConnection connection = new SqlConnection(connectionstring))
    {
        string query = "SELECT TOP (1) [ZVNr] ZVNR_TABLE WHERE [ZVNr] = @zvnr order by [ZVNr] DESC";
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@zvnr", "20170530-01");
            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
            }
        }
    }
      
