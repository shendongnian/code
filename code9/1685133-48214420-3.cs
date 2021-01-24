        OleDbDataReader reader = command.ExecuteReader();
        if(reader.Read())
        {
           string result = reader.GetValue(0).ToString();
           MessageBox.Show(result);
         }
        connection.Close();
