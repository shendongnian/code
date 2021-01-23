    string formatString= "yyMMddHHmmss";
    DateTime Occurrence_Time,Recovery_Time;
    string strOccurrence = Meter_data.Substring(161, 12);
    string strRecovery = Meter_data.Substring(173, 12);
    
    if (DateTime.TryParseExact(strOccurrence,formatString, CultureInfo.InvariantCulture,DateTimeStyles.None,out Occurrence_Time))
    {
        if (DateTime.TryParseExact(strRecovery,formatString, CultureInfo.InvariantCulture,DateTimeStyles.None,out Recovery_Time))
        {
          cmd2.Parameters.Add("@Occurrence_Time",SqlDbType.DateTime).Value=Occurrence_Time;
          cmd2.Parameters.Add("@Recovery_Time",SqlDbType.DateTime).Value=Recovery_Time;
        }
    }
