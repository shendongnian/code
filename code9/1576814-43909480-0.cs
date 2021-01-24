    private void SearchButtonClick(object sender, RoutedEventArgs e)
    {
        base_connection.ConnectionString = "Data Source=New_test_base.db;Version=3;New=False;Compress=True;";
        base_connection.Open();
        sqlite_cmd= base_connection.CreateCommand();
        sqlite_cmd.CommandText = "select Tag, substr(Description, 1, 2) as Description from Classes where Description = 'rty'";// "select * from Classes where Description = '"+ SearchString.Text+"'";
        DbData = sqlite_cmd.ExecuteReader();
        DbData.Read();
        string myreader = DbData["Tag"].ToString()+DbData["Description"].ToString();
        MessageBox.Show(myreader);
    }
