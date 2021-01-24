    StringBuilder sbCmd = new StringBuilder();
      sbCmd.Append("SELECT COUNT(*) ");
      sbCmd.Append("FROM Trip ");
      sbCmd.Append("WHERE (ShipCode = @ShipCode) ");
      sbCmd.Append("AND Date < @TodayPlusWeek");
    string txtCmd = sbCmd.ToString();
    int iQryReturn;
    using (SqlCommand cmd = new SqlCommand(txtCmd, conn)) {
        cmd.CommandType = CommandType .Text;
        cmd.Parameters.AddWithValue("@ShipCode", iShipCode;);
        cmd.Parameters.AddWithValue("@TodayPlusWeek", dtTodayPlusWeek);
        try {
            conn.Open();
            iQryReturn = (int)cmd.ExecuteScalar();
        }
        catch(Exception ex) {
            iQryReturn = -1;
            // Your Exception handling here
        }
        finally {
            conn.Close();
            // Your cleanup code if any
        }
    }
