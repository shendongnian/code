    try
    {
          int[] result = Server.ConnectionContext
                        .ExecuteNonQuery(stringColleciton);
    }
    catch(SqlException se)
    {
          //write log, show message
    }
    catch(Exception e)
    {
          //write log, show message
    }
