    using Oracle.DataAccess.Client;
    OracleConnection myConnection = new OracleConnection();
    myConnection.ConnectionString = myConnectionString;
    myConnection.Open();
    //execute queries 
    myConnection.Close();
