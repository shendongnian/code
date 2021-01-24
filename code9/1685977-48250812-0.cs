         public List<User> Get(int? id = null)
        {
        SqlDataReader reader = null;
        SqlConnection myConnection = new SqlConnection();
        myConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Downloads\SERVER\SERVER\App_Data\dbCoffeeBreak_.mdf;Integrated Security=True";
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.CommandType = CommandType.Text;
        if(id !=null)
            sqlCmd.CommandText = "Select * from tbUsers where ID=" + id + "";
        else
              sqlCmd.CommandText = "Select * from tbUsers ";
        sqlCmd.Connection = myConnection;
        myConnection.Open();
        reader = sqlCmd.ExecuteReader();
        List<User> users = List<User>();
        while (reader.Read())
        {
            u = new User();
            u.ID = Convert.ToInt32(reader.GetValue(0));
            u.Login = reader.GetValue(1).ToString();
            u.Password = reader.GetValue(2).ToString();
            u.Avatar = reader.GetValue(3).ToString();
            u.Email = reader.GetValue(4).ToString();
            u.Online = Convert.ToBoolean(reader.GetValue(5));
            users.Add(u);
        }
        myConnection.Close();
        return users;
    }
