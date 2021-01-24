    for (int j = 1; j < TDData.Length; j +=5) 
    {
    sqlconn.Open(); 
    SqlCommand Insertcmd = new SqlCommand(InsertData, sqlconn); 
    string TestSuite= TDData[j];
