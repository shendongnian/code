    using (SqlConnection connection = new SqlConnection(ConnectionString))
    {
        SqlCommand command = new SqlCommand(queryString, connection);
        try
        {
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                { 
                    MessageBox.Show(reader.GetValue(1).ToString());
                }
                //dont need to close the reader as the using statement will dispose of it once finished anyway
            }
 
        connection.Close();
        }
        catch (Exception ex)
        {
            connection.Close();
            Console.WriteLine(ex.Message);
            //or, depending on the package Debug.WriteLine(ex.Message);
        }
    }
