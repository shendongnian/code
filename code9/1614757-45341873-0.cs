    public int getLatestReading(string connstr, string gId, string mId, DateTime date)
        {
            int active = 0;
            MySqlConnection myconn = new MySqlConnection(connstr);
            String sqlstr = "Select max(ar.ActualReading) From actualmeterreading ar Inner Join meterreadingrecords mr On mr.ActualMeterReadingID = ar.ID Inner join machinemeterreadinglist mml on mml.ID = ar.MachineMeterReadingId Inner join grouping g on g.ID = mml.Grouping inner join machines m on m.ID = mml.MachineID where g.ID = '" + gId + "' and m.ID = '" + mId + "' and mr.rDate > '" + date + "'";
            MySqlCommand cmd = new MySqlCommand(sqlstr, myconn);
            myconn.Open();
            active = !Convert.IsDBNull(cmd.ExecuteScalar())?Convert.ToInt32(cmd.ExecuteScalar()):0;
            myconn.Close();
            myconn.Dispose();
            return active;
        }
