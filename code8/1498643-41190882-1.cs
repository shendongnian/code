    private string insertQuery = "INSERT INTO `virtualstartupdb`.`item` (`name`, `title`, `description`, `language_id`, `price`, `item_type_id`, `costs`) VALUES ( @name, @title, @description, @language_id, @price, @item_type_id, @costs );";
    private string connectionString = "Connection String here";
    public void InsertRecord(MyInsertType newData)
    {
        using (var cn = new MySqlConnection(connectionString))
        using (var cmd = new MySqlCommand(insertQuery, cn))
        {
            //guessing at column types and lengths here
            cmd.Parameters.Add("@name", MySqlDbType.VarChar, 20).Value = newData._name;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar, 20).Value = newData._title;
            cmd.Parameters.Add("@description", MySqlDbType.VarString, 1000).Value = newData._description;
            cmd.Parameters.Add("@language_id", MySqlDbType.VarChar, 5).Value = newData._language_id;
            cmd.Parameters.Add("@price", MySqlDbType.Decimal).Value = newData._price;
            cmd.Parameters.Add("@item_type_id", MySqlDbType.Int64).Value = newData._item_type_id;
            cmd.Parameters.Add("@costs", MySqlDbType.Decimal).Value = newData._costs;
            cn.Open();
            cmd.ExecuteNonQuery();
        }
    }
