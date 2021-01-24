    public Int32 ExecuteGenericSP(string spName, out int errNum, out string errMsg, params object[] lstParams)
    {
        Int32 returnValue;
        /* Aqui */
        SqlDatabase _sqlDatabase = new SqlDatabase(getConnectionString());
        using (DbConnection con = _sqlDatabase.CreateConnection())
        {
            DbCommand cmd = _sqlDatabase.GetStoredProcCommand(spName);
            _sqlDatabase.DiscoverParameters(cmd);
            int n = 3;
            errNum = 0;
            errMsg = "";
            cmd.Parameters["@RETURN_VALUE"].Value = 0;
            cmd.Parameters["@errNum"].Value = 0;
            cmd.Parameters["@errDes"].Value = "";
            foreach (object o in lstParams)
            {
                if (cmd.Parameters[n].DbType.ToString() == "DateTime")
                    cmd.Parameters[n].Value = Convert.ToDateTime(o);
                else
                    cmd.Parameters[n].Value = o.ToString();
                n++;
            }
            returnValue = _sqlDatabase.ExecuteNonQuery(cmd);
            errNum = Convert.ToInt16(_sqlDatabase.GetParameterValue(cmd, "errNum"));
            errMsg = _sqlDatabase.GetParameterValue(cmd, "errDes").ToString();
        }
        return returnValue;
    }
