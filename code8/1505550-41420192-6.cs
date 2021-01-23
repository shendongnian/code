    String updCmdTxt = "UPDATE ....";
    String insertCmdTxt = "INSERT ....";
    using (var scope = new TransactionScope())
    {
        using (var con = new OracleConnection(conStr))
        {
            bool isDuplicate = false;
            var insertcmd = new OracleCommand(insertCmdTxt, con);
            try
            {
                // Set parameters...
                insertcmd.ExecuteNonQuery();
            }
            catch (OracleException x)
            {
                isDuplicate = ...; //determine if the exception is about duplicates.
                if (!isDuplicate)
                {
                    throw;
                }
            }
            finally
            {
                insertcmd?.Dispose();
            }
            if (isDuplicate)
            {
                using (var updcmd = new OracleCommand(updCmdTxt, con))
                {
                    //Set parameters ...
                    updcmd.ExecuteNonQuery();
                }
            }
            scope.Complete();
        }
    }
