    SqlCommand cmd = new SqlCommand("", theActiveConnection);
    for (int ii = 0; ii < ptList.Length; ii++)    {
        sql = @"update [CCVT].[dbo].[_tb_NCVT_Points] set PointDateTime = CONVERT(datetime, '"
        + ptList[ii]._dateDt.ToString("yyyy-MM-dd HH:mm:ss.FFF") + "', 121), PointStatus = '"
        + ptList[ii]._statStr + "', PointValue =" + ptList[ii]._valDoub.ToString() 
        + " WHERE Pointkey = '" + ptList[ii]._pointName + "'; ";
        cmd.CommandText += sql;
    }
    try {
        theActiveConnection.Open();
        cmd.ExecuteNonQuery();
    }
    catch (Exception eX) {
       //handle exceptions
    } 
    finally {
        cmd.Dispose();
        theActiveConnection.Close();
    }
