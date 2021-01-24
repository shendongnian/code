    using (SqlConnection connection = new SqlConnection(connectionstring))
    {
        string query = "SELECT Count([ZVNr]) ZVNR_TABLE WHERE [ZVNr] = @zvnr order by [ZVNr] DESC";
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@zvnr", "20170530-01");
            try
            {
                connection.Open();
                int result = (int)cmd.ExecuteScalar();
            }
        }
    }
