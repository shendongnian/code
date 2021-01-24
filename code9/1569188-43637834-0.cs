    int rowsAffected;
    int txtContent = (int)customPayTextBox.Text;
    using (SqlConnection conn = new SqlConnection(connString)) {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand()) {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE [User] SET Money = Money - 100 WHERE (IsActive = '1') AND (Money >= @Money);";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Money", Money);
            rowsAffected = cmd.ExecuteNonQuery();                
        }
        conn.Close();
    }
