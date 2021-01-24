    public bool IsAccountValid(string userLogin, string userPassword)
        {
            bool flag = false;
    
            try
            {
                accessToDatabase.OpeningDatabase();
                String query = "SELECT * FROM Users where Username=@Username AND Password=@Password";
                SqlCommand sqlCmd = accessToDatabase.Command(query);
    
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", userLogin);
                sqlCmd.Parameters.AddWithValue("@Password", userPassword);
    
                 var reader = sqlCmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if(userPassword == reader[0].ToString())
                                {
                                    flag = true;
                                }
                            }
                        }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                accessToDatabase.ClosingDataBase();
            }
        return flag; //returns false if query does not exists...
    }
    
