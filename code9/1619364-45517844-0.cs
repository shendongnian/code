    sqlconn.Open();
    for (int j = 1; j < TDData.Length; j += 5)
    {
        SqlCommand Insertcmd = new SqlCommand(InsertData, sqlconn);
        string TestSuite = TDData[j];
        ...
    }
    sqlconn.Close();
    
