    using (SqlConnection sqlCon = new SqlConnection(connectionString))
    {
        SqlCommand sqlCmd = new SqlCommand("ULogin", sqlCon);
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.AddWithValue("@Username", textBox1.Text.Trim());
        sqlCon.Open();
        sqlCmd.ExecuteNonQuery();
        Clear();
    }
