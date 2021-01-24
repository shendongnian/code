    System.Data.IDbConnection cnn = new MySql.Data.MySqlClient.MySqlConnection("my Connection String");
        try
        {
            cnn.Open();
            MessageBox.Show("Connection Open ! ");
            cnn.Close();
        }
