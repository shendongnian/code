    ApplicationUser user;
    using (NpgsqlConnection db = new NpgsqlConnection(this.connectionString))
    {
        db.Open();
        using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT find_by_id(@user_id);", db))
        {
            cmd.Parameters.AddWithValue("user_id", userId);
            object result = cmd.ExecuteScalar();
            user = result == DBNull.Value ? null : (ApplicationUser)result;
        }
    }
