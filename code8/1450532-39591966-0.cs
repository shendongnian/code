    public void UpdateUser(User userToUpdate)
    {
        try
        {
            string sqlStatement = @"UPDATE USERS " +
                                   "SET DisplayName = @DisplayName, Username = @Username" +
                                   "WHERE Id = @Id";
            using (SqlConnectionconn = new SqlConnection("connection string here"))
            using (SqlCommand cmd = new SqlCommand(sqlStatement, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@Id", userToUpdate.Id));
                cmd.Parameters.Add(new SqlParameter("@DisplayName", userToUpdate.DisplayName));
                cmd.Parameters.Add(new SqlParameter("@UserName", userToUpdate.UserName));
                cmd.ExecuteNonQuery();
            }
        }
        catch (DbException ex)
        {
            throw ExceptionHandler.CreateSystemException(ex, ErrorStrings.DATABASE_ERROR);
        }
    }
