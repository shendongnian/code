    public void WriteData(string tableName, string designation, string price, string group, string weight, string deliveryTime)
    {
        _command.CommandText = "INSERT INTO " + 
            tableName + " (ID, Designation, Price, Group, Weight, deliveryTime) 
            VALUES (?,?,?,?,?,?)";
        OleDbCommand addDataCommand = new OleDbCommand(_command.CommandText, _connection);     
        addDataCommand .Parameters.AddWithValue("ID", GetNextHighestItemNumber());
        addDataCommand .Parameters.AddWithValue("Designation", designation);
        addDataCommand .Parameters.AddWithValue("Price", price);
        addDataCommand .Parameters.AddWithValue("Group", group);
        addDataCommand .Parameters.AddWithValue("Weight", weight);
        addDataCommand .Parameters.AddWithValue("DeliveryTime", deliveryTime);
        OpenConnection();
        _command.ExecuteNonQuery();
        CloseConnection();
        System.Windows.Forms.MessageBox.Show("Success");
    }
