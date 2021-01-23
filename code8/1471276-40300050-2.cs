    private DataTable FilterRecords()
    {
        bool where_set = false;
        DataTable table = new DataTable();
        string constring = "datasource=localhost;port=3306;username=root;password=password";
        string commandText = "select BookName, Publisher, Category, Edition, Year,"
                             + "Location from library.add_update "
                             + "where "
        // build your own filters
        //
        if (filter_by_name)
        {
            commandText += "name like '%" + varName + "%'";
            where_set = true;
        }
        if (filter_by_publisher)
        {
            if (where_set) commandText += " and ";
            commandText += "name like '%" + varName + "%'";
            where_set = true;
        }
        using (MySqlConnection connection = new MySqlConnection(constring))
        {
            MySqlDataAdapter adp = new MySqlDataAdapter();
            adp.SelectCommand = new MySqlCommand(commandText, connection);
            adp.Fill(table);
        }
        return table;
    }
