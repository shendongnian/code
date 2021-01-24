    int rowsAffected;
    string connString = "";
    int txtContent = (int)customPayTextBox.Text;
    using (SqlConnection conn = new SqlConnection(connString)) {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand()) {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE [User] SET Money = Money - 100 WHERE (IsActive = '1') AND (UserID = @UserID) AND (Money >= @Money);";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Money", Money);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            rowsAffected = cmd.ExecuteNonQuery();
        }
        conn.Close();
    }
    if (rowsAffected == 0) { /* user not found OR not enough funds */ }
    else { /* at least 1 row was updated */ }
