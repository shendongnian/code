       DateTime startdate = Convert.ToDateTime(metroLabel8.Text);
       DateTime enddate = Convert.ToDateTime(metroLabel9.Text);
       ...
       // Make sql readable
       string sql = 
         @"Select [LedId],
                  [LedName] 
             from [Ledger] 
            where Date >= @prmStartDate and Date <= @prmEndDate";
    
       // wrap IDisposable (SqlCommand) into using
       using (SqlCommand cmd = new SqlCommand(sql, con)) {
         cmd.Parameters.Add("@prmStartDate", SqlDbType.DateTime).Value = startDate; 
         cmd.Parameters.Add("@prmEndDate", SqlDbType.DateTime).Value = endDate;
    
         ... 
       }
