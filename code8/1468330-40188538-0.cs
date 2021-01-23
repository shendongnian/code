    command.CommandType = CommandType.StoredProcedure;                  
    command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar)).Value = user.userName.Trim();
    command.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar)).Value = user.password.Trim();
    command.Parameters.Add(new SqlParameter("@Mail", SqlDbType.VarChar)).Value = user.mail.Trim();
    //Assuming that the user object has a field named Birthday
    command.Parameters.Add(new SqlParameter("@Birthday", SqlDbType.Date)).Value = user.Birthday; 
    command.ExecuteNonQuery();
