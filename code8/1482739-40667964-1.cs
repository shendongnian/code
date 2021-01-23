    using (IDbCommand SqlCmd = CommandProvider.GetSPCommand(conn))
    {
        SqlCommand fullSqlCommand = SqlCmd as SqlCommand;
        if (fullSqlCommand != null)
        {
           // setup sqlcmd with output paramter and executenonquery ...
           ID = Convert.ToInt32(fullSqlCommand.Parameters["ID"].Value);
        }
        else
        {
            //Some failsafe
        }
     }
