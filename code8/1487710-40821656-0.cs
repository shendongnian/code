    using (SqlConnection conn = new SqlConnection("ConnectionString"))
    {
    conn.Open();
    string query = "SELECT COUNT(*) FROM Some_Table WHERE Val > 5";
    SqlCommand command = new SqlCommand(query, con);
    Int32 count = (Int32) cmd.ExecuteScalar()
    }
