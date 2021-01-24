    public DataTable ExecuteDataTable(string query)
    {
        DataTable dt = new DataTable(); // create a DataTable for containing your data
        OpenConnection(con); // method will open connection con
        SQLiteCommand com = new SQLiteCommand(query, con);
        SQLiteDataAdapter sda = new SQLiteDataAdapter(com); // fill data to the adapter
        sda.Fill(dt); // fill adapter's data to DataTable
        CloseConnection(con); // method will close connection con
        return dt;
    }
