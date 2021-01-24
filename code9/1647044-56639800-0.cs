    MySqlConnectionStringBuilder ConStD = new MySqlConnectionStringBuilder();
    
    ConStD.Server = "Hostname that get from Manage Access Hosts";
    ConStD.Port = Port that get from Manage Access Hosts;
    ConStD.Database = "YourDatabaseName";
    ConStD.UserID = "yourUsername";
    ConStD.Password = "yourpassword";
    
    try
    {
        MySqlConnection conn = new MySqlConnection(ConStD.ToString());
        conn.Open();
        MessageBox.Show("connection Success");
    }
    catch (MySqlException ex)
    {
        MessageBox.Show(ex.Message);
    }
