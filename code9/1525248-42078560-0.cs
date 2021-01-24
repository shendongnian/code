    public User GetUserInfo(string username, string pwd)
    {
        User user = null;
        DatabaseLayer dbLayer = new DatabaseLayer();
        try
        {
            SqlCommand sqlCmd = new SqlCommand("GetUserInfo");
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Username", username);
            sqlCmd.Parameters.AddWithValue("@Pwd", pwd);
            user = dbLayer.GetEntityList<User>(sqlCmd).FirstOrDefault();
        }
        finally
        {
            dbLayer.Dispose();
        }
        return user;
    }
