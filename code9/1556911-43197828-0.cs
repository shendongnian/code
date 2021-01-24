    SqlConnection con = new SqlConnection(DAL.cs);
    con.Open();
    SqlCommand com = new SqlCommand("UPDATE Student SET LastName = @LastName," +
            "FirstName = @FirstName," +
            "MiddleName = @MiddleName " +
            "WHERE ID = @ID", con);
    com.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = s.ID;
    com.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = s.LastName;
    com.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = s.FirstName;
    com.Parameters.AddWithValue("@MiddleName", SqlDbType.VarChar).Value = s.MiddleName;
    com.ExecuteNonQuery();
    con.Close();
