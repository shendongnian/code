    public int SetData(string query, OdbcParameterCollection parList)
    {
       ...  
       OdbcCommand command = new OdbcCommand(query, conn1);
       OdbcCommand.Parameters.Add(parList);
    }
    var parList = new OdbcParameterCollection();
    parList.Add("@servicenumber", OdbcType.Int);
    parList.Add("@title", OdbcType.VarChar);
    ...
    int ret = SetData(query, parList);
