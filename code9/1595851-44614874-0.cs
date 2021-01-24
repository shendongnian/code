    String strSQL = @"Insert into UAVData
                     ([Day],[Time],Latitude,Longitude,
                      Altitude,Temperature,Windspeed) 
                      values(@day,@time, @lat,@long, @alt, @temp, @wind)";
    using(OleDbConnection con = new OleDbConnection(.....))
    using(OleDbCommand CmdSql = new OleDbCommand(cmdText, con))
    {
        con.Open();
        CmdSql.Parameters.Add("@Day", OleDbType.Integer);
        CmdSql.Parameters.Add("@Time", OleDbType.BigInt);
        CmdSql.Parameters.Add("@Lat", OleDbType.Double)
        CmdSql.Parameters.Add("@Long", OleDbType.Double);
        CmdSql.Parameters.Add("@Alt", OleDbType.Double);
        CmdSql.Parameters.Add("@Temp", OleDbType.Double);
        CmdSql.Parameters.Add("@Wind", OleDbType.Double);
        
        for (int j = 0; j < timeList.Count; j++)
        {
            CmdSql.Parameters["@Day"].Value = 1
            CmdSql.Parameters["@Time"].Value = Convert.ToInt64(timeList[j].InnerText);
            CmdSql.Parameters["@Lat"].Value = Convert.ToDouble(latList[j].InnerText
            CmdSql.Parameters["@Long"].Value = Convert.ToDouble(longList[j].InnerText);
            CmdSql.Parameters["@Alt"].Value = Convert.ToDouble(altList[j].InnerText);
            CmdSql.Parameters["@Temp"].Value = Convert.ToDouble(tempList[j].InnerText);
            CmdSql.Parameters["@Wind"].Value = Convert.ToDouble(windList[j].InnerText);
            CmdSql.ExecuteNonQuery();
        }
    }
