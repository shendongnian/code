    connection.Open();
    OleDbCommand command = new OleDbCommand();
    command.Connection = connection;
    command.CommandText = @"SELECT CONTENT FROM " + tab + " GROUP BY CONTENT ORDER BY MIN(CHAP)";
    OleDbDataAdapter dAdap = new OleDbDataAdapter(command);
    DataSet dSet = new DataSet();
    dAdap.Fill(dSet);
    string[] chkList = new string[dSet.Tables[0].Rows.Count]
    for (int i = 0; i < dSet.Tables[0].Rows.Count; i++)
    {
        chkList[i]=dSet.Tables[0].Rows[i][0].ToString(); //This is the part where the items are populated
    }
    connection.Close();
