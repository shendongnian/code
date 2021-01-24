    public Bool SaveRequest(Request newRequestData)
    {
        var connection = new connection();
        bool isSuccess = true;
    
        OracleConnection Conn = connection._GetInstance();
        OracleCommand Cmd = new OracleCommand();
        Conn.Open();
        Cmd.Connection = Conn;
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.CommandText = "PackageRequests.InsertNewRequest";
        Cmd.BindByName = true;
    
        // IN PARAMETERS...
        Cmd.Parameters.Add(new OracleParameter("P_LOCATION", OracleDbType.Varchar2, newRequestData.location, ParameterDirection.Input));
    
        // OUT PARAMETER (Here I recover the master table ID)
        Cmd.Parameters.Add(new OracleParameter("P_NEW_ID", OracleDbType.Int32)).Direction = ParameterDirection.Output;
    
        // Initialize the Transaction 
        OracleTransaction transaction = Conn.BeginTransaction(IsolationLevel.ReadCommitted);
        try
        {
            //Execute the first SP
            Cmd.ExecuteNonQuery();
            string newId = Convert.ToString(Cmd.Parameters["P_NEW_ID"].Value);
    
            // Calls another function and pass Oracle Connection, and master table ID like parameters
            InsertRequestDetail(Conn, newId);
    
            transaction.Commit();
        }
        catch (OracleException ex)
        {   
            //If something goes wrong rollback.
            transaction.Rollback();
            isSuccess = false;
        }
        finally
        {
            Conn.Close();
        }
        return isSuccess;
    }
    
    private void InsertRequestDetail(OracleConnection Conn, string newId)
    {
    
        OracleCommand Cmd = new OracleCommand();
        Cmd.Connection = Conn;
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.CommandText = "MY_PACKAGE.AnotherSPName";
        Cmd.BindByName = true;
    
        //IN - OUT PARAMS
        Cmd.Parameters.Add(new OracleParameter("...
        
        Cmd.ExecuteNonQuery();
    }
