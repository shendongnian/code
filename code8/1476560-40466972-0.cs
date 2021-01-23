    public void database_connect(String item_code, String des, String unit, double price)
    {
        try
        {
            connect.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connect;
            command.CommandText = "INSERT into item (item_code, description, unit, price) values ('" + item_code + "', '" + des + "', '" + unit + "', " + price + ")";
            int insertedRows = command.ExecuteNonQuery();
            return insertedRows > 0;
        }
        catch(Exception e)
        {
            Debug.WriteLine(e.Source);
        }
        finally
        {
            connect.Close();
        }
        // false will be returned if exception will be thrown
        return false;
    }
