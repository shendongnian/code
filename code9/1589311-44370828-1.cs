    public OracleDataReader ExecuteReader(string SelectQuery, string conString)
            {
            try
            {
            OpenDbConnection(conString);
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = SelectQuery;
            cmd.CommandType = System.Data.CommandType.Text;
            con.Open(); 
            OracleDataReader ora_dataReader = cmd.ExecuteReader();
        }
        catch (Exception ex)
        {
            Logging.LogMessage(Logging.LogLevel.Error, 0, "DAL", this.GetType().Name, ex.Message + " : " + ex.StackTrace);
            throw ex;
        }
        finally
        {
         con.close();
         con.Dispose(); 
        }
            return ora_dataReader;
    }
