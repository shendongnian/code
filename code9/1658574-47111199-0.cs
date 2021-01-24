    string query = "Select * from customers where cid = @cid";
    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
    {
        adapter.SelectCommand.Parameters.Add("@cid", SqlDbType.Int).Value = profile_label.Text;
    
        try
        {
            adapter.Fill(dt);
        }
        catch
        {
        }
    }
