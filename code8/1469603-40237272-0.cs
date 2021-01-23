	cmd2.Parameters.Add("@Device_ID", SqlDbType.VarChar, 50).Value = device_Id;
	cmd2.Parameters.Add("@Event_ID", SqlDbType.VarChar, 50).Value = event_Id;
	cmd2.Parameters.Add("@Occurrence_Time", SqlDbType.DateTime, 50).Value = DBNull.Value;
	cmd2.Parameters.Add("@Recovery_Time", SqlDbType.DateTime, 50).Value = DBNull.Value;
	
