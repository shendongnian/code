    public DataTable LoadDataFromDatabase(string query)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(YourConnectionString))
        using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
        {
            try
            {
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //handle error if needed
            }
        }
        return dt;
    }
