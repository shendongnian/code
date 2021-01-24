    while (reader.Read())
    {
        var timeIn = reader["time_in"].ToString();
        var timeOut = reader["time_out"].ToString();
        var workerFullName = reader["worker_fullname"].ToString();
        var date = reader["date"].ToString();
    
        //move to utility method 
        DateTime timeInDateTime;
        DateTime.TryParseExact(timeIn, "h:mm:ss tt", null, DateTimeStyles.None, out timeInDateTime);
    
        DateTime timeOutDateTime;
        DateTime.TryParseExact(timeOut, "h:mm:ss tt", null, DateTimeStyles.None, out timeOutDateTime);
    
        DateTime dateParsed;
        DateTime.TryParseExact(date, "MMM dd, yyyy", null, DateTimeStyles.None, out dateParsed);
    
        //add to list
    }
