    using (var connection = new OleDbConnection()) {
        connection.ConnectionString =
            @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Users\...\Used.accdb";
        try {
            connection.Open();
            //TODO: do something with the connection
        } catch (Exception ex) {
            MessageBox.Show("Connection Failed\r\n\r\n" + ex.Message);
        }
    }
