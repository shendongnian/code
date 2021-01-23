	var occuranceDate = DateTime.ParseExact(Meter_data.Substring(161, 12), "yyMMddHHmmss", CultureInfo.InvariantCulture);
	var recoveryDate = DateTime.ParseExact(Meter_data.Substring(173, 12), "yyMMddHHmmss", CultureInfo.InvariantCulture);
	
	cmd2.Parameters.Add("@Device_ID", SqlDbType.VarChar, 50).Value = device_Id;
	cmd2.Parameters.Add("@Event_ID", SqlDbType.VarChar, 50).Value = event_Id;
	cmd2.Parameters.Add("@Occurrence_Time", SqlDbType.DateTime, 50).Value = occuranceDate'
	cmd2.Parameters.Add("@Recovery_Time", SqlDbType.DateTime, 50).Value = recoveryDate;
	int Device_Events_rows_executed = cmd2.ExecuteNonQuery();
	Console.WriteLine("Rows Executed: '{0}'", Device_Events_rows_executed);
