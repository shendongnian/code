    public static DataSet populatelistview()
    {
        OleDbConnection myConnection = GetConnection();
        string query = "SELECT * FROM trainlines_"; 
        OleDbCommand command = new OleDbCommand(query, myConnection); 
        command.Connection = myConnection;
    
        DataSet trainlinedata = new DataSet();
        trainlinedata.Clear();
        OleDbDataAdapter datareader = new OleDbDataAdapter(command);
        datareader.Fill(trainlinedata);
        myConnection.Close();
        return trainlinedata;
    }
