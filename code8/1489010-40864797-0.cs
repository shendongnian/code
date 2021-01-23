    DateTime startdate = Convert.ToDateTime(metroLabel8.Text);
    DateTime enddate = Convert.ToDateTime(metroLabel9.Text);
    SqlCommand cmd = new SqlCommand("Select [LedId],[LedName] from [Ledger] where Date >= @startDate and Date <= @endDate", con);
    
    SqlParameter startParameter = cmd.Parameters.Add("@startDate ",
                    System.Data.SqlDbType.DateTime);
    SqlParameter endParameter = cmd.Parameters.Add("@endDate",
                    System.Data.SqlDbType.DateTime);
    
    startParameter.Value = startdate;
    endParameter.Value = enddate;
    
    cmd.Parameters.Add(startParameter);
    cmd.Parameters.Add(endParameter);
