    SqlCommand cmd = new SqlCommand("", theActiveConnection);
    StringBuilder sql = new StringBuilder();
    for (int ii = 0; ii < ptList.Length; ii++)    {
        sql.AppendLine($"UPDATE [CCVT].[dbo].[_tb_NCVT_Points]"); 
		sql.AppendLine($"SET PointDateTime = CONVERT(datetime, @PointDateTime{ii}, 121), PointStatus = @PointStatus{ii}, PointValue = @PointValue{ii}");
        sql.AppendLine($"WHERE Pointkey = '@PointKey{ii};");
		cmd.Parameters.AddWithValue("@PointDateTime"+ii,ptList[ii]._dateDt.ToString("yyyy-MM-dd HH:mm:ss.FFF"));
		cmd.Parameters.AddWithValue("@PointStatus"+ii,ptList[ii]._statStr);
		cmd.Parameters.AddWithValue("@PointValue"+ii,ptList[ii]._valDoub.ToString());
		cmd.Parameters.AddWithValue("@Pointkey"+ii,ptList[ii]._pointName);
        
    }
    try {
        cmd.CommandText = sql.ToString();
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
