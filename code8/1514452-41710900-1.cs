        DataSet ds = new DataSet();
        string strSQL = string.Empty;
        ATSSPCommon.SQLDB myDB = null;
        string ret = string.Empty;
        try
        {
            ........
            ds = myDB.GetDataSet(strSQL);
        }
        catch (Exception ex)
        {
            ....
        }
        finally
        {
        }
        if (ds.Tables[0].Rows.Count > 0) // this could be the error
            return ds.Tables[0];
        else
            return null;
