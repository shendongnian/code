    static public MySqlConnection db_connection()
    {
        try
        {
            var conn = "Server=myhomeserver.net;Database=addonInstaller;Uid=root;Pwd=g278535814;";
            var connect = new MySqlConnection(conn);
            connect.Open();
            return connect;
        }
        catch (MySqlException e)
        {
            MessageBox.Show("Could not Connect to Server");
        }
        return null;
    }
